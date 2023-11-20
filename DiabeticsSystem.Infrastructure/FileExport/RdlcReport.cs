using AspNetCore.Reporting;
using DiabeticsSystem.Application.Contracts.Infrastructure;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;
using System.Text;

namespace DiabeticsSystem.Infrastructure.FileExport
{
    public class RdlcReport  : IRdlcReport
    {
        public byte[] ExportPatientMovementToPDF(string path,List<PatientMovementExportDTO> entity)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            string mimeType = "";
            int extension = 1;

            Dictionary<string,string> parameter = new()
            {
                { "paramReportTitle", "Patient Movement" }
            };
            LocalReport localReport = new(path);
            localReport.AddDataSource("DsPatientMovement", entity);

            var result = localReport.Execute(RenderType.Pdf,extension,parameter,mimeType);
            //[..result.MainStream] ;
            return result.MainStream;
        }
    }
}
