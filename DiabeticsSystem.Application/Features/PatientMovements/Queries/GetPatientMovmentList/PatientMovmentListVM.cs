namespace DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList
{
    public class PatientMovmentListVM
    {
        public Guid Id { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public CustomerDTO Customer { get; set; } = default!;
        public ProductDTO Product { get; set; } = default!;
    }
}
