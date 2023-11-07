using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList;

namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport
{
    public class PatientMovementExportDTO
    {
        public string? Barcode { get; set; }
        public DateTime CreatedDate { get; set; }
        public CustomerDTO Customer { get; set; } = default!;
        public ProductDTO Product { get; set; } = default!;
    }
}
