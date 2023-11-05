using DiabeticsSystem.Domain.Common;

namespace DiabeticsSystem.Domain.Entities
{
    public class PatientMovement :AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CostomerId { get; set; }
        public Guid ProductId { get; set; }
        public string? Barcode { get; set; }
    }
}
