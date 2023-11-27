using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Contracts.Infrastructure
{
    public interface IRdlcReport
    {
        byte[] ExportAllPatientsMovementToPDF(string path, List<PatientMovementExportDTO> entity);
        byte[] ExportPatientMovementByCustomerToPDF(string path, List<PatientMovementExportDTO> entity);
    }
}
