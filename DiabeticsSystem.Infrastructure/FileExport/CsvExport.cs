using CsvHelper;
using DiabeticsSystem.Application.Contracts.Infrastructure;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;
using System.Globalization;
using System.Text;

namespace DiabeticsSystem.Infrastructure.FileExport
{
    public class CsvExport : ICsvExport
    {
        public byte[] ExportPatientMovementToCsv(List<PatientMovementExportDTO> exportDTOs)
        {
            using var memoryStream = new MemoryStream();
            using (var writer = new StreamWriter(memoryStream, Encoding.UTF8))
            {
                using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(exportDTOs);
            }

            return memoryStream.ToArray();
        }
    }
}
