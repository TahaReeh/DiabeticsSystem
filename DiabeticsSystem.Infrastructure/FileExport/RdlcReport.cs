using AspNetCore.Reporting;
using DiabeticsSystem.Application.Contracts.Infrastructure;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;

namespace DiabeticsSystem.Infrastructure.FileExport
{
    public class RdlcReport : IRdlcReport
    {
        private readonly string mimeType = "";
        private readonly int extension = 1;
        private Dictionary<string, string> Parameter { get; set; } = default!;

        public byte[] ExportAllPatientsMovementToPDF(string path, List<PatientMovementExportDTO> entity)
        {
            Parameter = new()
            {
                { "paramReportTitle", "All Patient Movement" }
            };
            LocalReport localReport = new(path);

            localReport.AddDataSource("DsPatientMovement2", entity);
            
            var result = localReport.Execute(RenderType.Pdf, extension, Parameter, mimeType);
            return result.MainStream;
        }


        public byte[] ExportPatientMovementByCustomerToPDF(string path, List<PatientMovementExportDTO> entity)
        {
            Parameter = new()
            {
                { "paramReportTitle", $"{entity.FirstOrDefault()?.CustomerName} Movement" }
            };
            LocalReport localReport = new(path);
            localReport.AddDataSource("DsPatientMovement2", entity);

            var result = localReport.Execute(RenderType.Pdf, extension, Parameter, mimeType);
            return result.MainStream;
        }
    }
}
