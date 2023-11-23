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
            var allPatientMoves = _mapper.Map<List<PatientMovementExportDTO>>(
                (await _unitOfWork.PatientMovement.GetAllAsync(includeProperties: "Customer,Product")).OrderBy(x => x.CreatedDate));

            var patientExportFileDTO = new PatientMovementExportFileVM();

            if (request.ExportType == 1)
            {
                var fileData = _csvExport.ExportPatientMovementToCsv(allPatientMoves);
                patientExportFileDTO = new PatientMovementExportFileVM()
                {
                    ContentType = "text/csv",
                    Data = fileData,
                    PatientMovementExportFileName = $"{Guid.NewGuid()}.csv"
                };
            }
            else if (request.ExportType == 2)
            {
                var fileData = _rdlcReport.ExportPatientMovementToPDF(request.Path, allPatientMoves);
                patientExportFileDTO = new PatientMovementExportFileVM()
                {
                    ContentType = "application/pdf",
                    Data = fileData,
                    PatientMovementExportFileName = $"{Guid.NewGuid()}.pdf"
                };
            }
            return patientExportFileDTO;
        }

    }
}
