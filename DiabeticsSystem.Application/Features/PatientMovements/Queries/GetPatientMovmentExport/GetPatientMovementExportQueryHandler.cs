using AutoMapper;
using DiabeticsSystem.Application.Contracts.Infrastructure;
using DiabeticsSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport
{
    public class GetPatientMovementExportQueryHandler : IRequestHandler<GetPatientMovementExportQuery, PatientMovementExportFileVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICsvExport _csvExport;
        private readonly IRdlcReport _rdlcReport;

        public GetPatientMovementExportQueryHandler(IUnitOfWork unitOfWork,
            IMapper mapper,
            ICsvExport csvExport,
            IRdlcReport rdlcReport)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _csvExport = csvExport;
            _rdlcReport = rdlcReport;
        }

        public async Task<PatientMovementExportFileVM> Handle(GetPatientMovementExportQuery request, CancellationToken cancellationToken)
        {

            var PatientMovesObj = (await _unitOfWork.PatientMovement.GetAllAsync(includeProperties: "Customer,Product")).OrderBy(x => x.CreatedDate).ToList();

            List<PatientMovementExportDTO> allPatientMoves = new();
            PatientMovesObj.ForEach(x =>
            {
                allPatientMoves.Add(new PatientMovementExportDTO
                {
                    Barcode = x.Barcode,
                    CreatedDate = x.CreatedDate,
                    CustomerName = x.Customer.Name,
                    ProductName = x.Product.Name
                });
            });

            PatientMovementExportFileVM exportFile = new();

            switch (request.ExportType)
            {
                case 1:
                    {
                        var fileData = _csvExport.ExportPatientMovementToCsv(allPatientMoves);
                        exportFile = new PatientMovementExportFileVM()
                        {
                            ContentType = "text/csv",
                            Data = fileData,
                            PatientMovementExportFileName = $"{Guid.NewGuid()}.csv"
                        };
                        break;
                    }

                case 2:
                    {
                        var fileData = _rdlcReport.ExportAllPatientsMovementToPDF(request.Path, allPatientMoves);
                        exportFile = new PatientMovementExportFileVM()
                        {
                            ContentType = "application/pdf",
                            Data = fileData,
                            PatientMovementExportFileName = $"{Guid.NewGuid()}.pdf"
                        };
                        break;
                    }

                case 3:
                    {
                        var PatientMovesBuCustomerObj = (await _unitOfWork.PatientMovement.GetAllAsync(u =>
                            u.CustomerId == request.CustomerId, includeProperties: "Customer")).ToList();

                        List<PatientMovementExportDTO> PatientMoves = new();

                        PatientMovesBuCustomerObj.ForEach(x =>
                        {
                            PatientMoves.Add(new PatientMovementExportDTO
                            {
                                Barcode = x.Barcode,
                                CreatedDate = x.CreatedDate,
                                CustomerName = x.Customer.Name,
                                ProductName = x.Product.Name
                            });
                        });

                        var fileData = _rdlcReport.ExportPatientMovementByCustomerToPDF(request.Path, PatientMoves);

                        exportFile = new PatientMovementExportFileVM()
                        {
                            ContentType = "application/pdf",
                            Data = fileData,
                            PatientMovementExportFileName = $"{Guid.NewGuid()}.pdf"
                        };
                        break;
                    }
            }
            return exportFile;
        }

    }
}
