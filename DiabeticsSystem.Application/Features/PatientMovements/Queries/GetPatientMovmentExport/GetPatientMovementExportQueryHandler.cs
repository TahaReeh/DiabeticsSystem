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

        public GetPatientMovementExportQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ICsvExport csvExport)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _csvExport = csvExport;
        }

        public async Task<PatientMovementExportFileVM> Handle(GetPatientMovementExportQuery request, CancellationToken cancellationToken)
        {
            var allPatientMoves = _mapper.Map<List<PatientMovementExportDTO>>(
                (await _unitOfWork.PatientMovement.GetAllAsync(includeProperties:"Customer,Product")).OrderBy(x => x.CreatedDate));

            var fileData = _csvExport.ExportPatientMovementToCsv(allPatientMoves);

            var patientExportFileDTO = new PatientMovementExportFileVM()
            {
                ContentType = "text/csv",
                Data = fileData,
                PatientMovementExportFileName = $"{Guid.NewGuid()}.csv"
            };

            return patientExportFileDTO;
        }
    }
}
