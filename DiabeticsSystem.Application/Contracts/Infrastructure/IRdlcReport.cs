using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;

namespace DiabeticsSystem.Application.Contracts.Infrastructure
{
    public interface IRdlcReport
    {
        byte[] ExportAllPatientsMovementToPDF(string path, List<PatientMovementExportDTO> entity);
        byte[] ExportPatientMovementByCustomerToPDF(string path, List<PatientMovementExportDTO> entity);
    }
}
