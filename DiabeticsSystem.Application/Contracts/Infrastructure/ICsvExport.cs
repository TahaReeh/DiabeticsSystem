using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;

namespace DiabeticsSystem.Application.Contracts.Infrastructure
{
    public interface ICsvExport
    {
        byte[] ExportPatientMovementToCsv(List<PatientMovementExportDTO> exportDTOs);
    }
}
