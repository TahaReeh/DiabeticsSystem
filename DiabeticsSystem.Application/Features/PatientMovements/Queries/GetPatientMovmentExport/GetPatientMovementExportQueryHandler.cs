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
    public class GetPatientMovementExportQueryHandler(IUnitOfWork unitOfWork,
        IMapper mapper,
        ICsvExport csvExport,
        IRdlcReport rdlcReport) : IRequestHandler<GetPatientMovementExportQuery, PatientMovementExportFileVM>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IMapper _mapper = mapper;
        private readonly ICsvExport _csvExport = csvExport;
        private readonly IRdlcReport _rdlcReport = rdlcReport;

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
                    PatientMovementExportFileName = $"{Guid.NewGuid()}.csv"
                };
            }
            return patientExportFileDTO;
        }

    }
}
