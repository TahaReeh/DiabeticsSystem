using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport
{
    public class GetPatientMovementExportQuery : IRequest<PatientMovementExportFileVM>
    {
        public Guid? CustomerId { get; set; } = Guid.Empty;
        public required int ExportType { get; set; }
        public string Path { get; set; } = string.Empty;
    }
}
