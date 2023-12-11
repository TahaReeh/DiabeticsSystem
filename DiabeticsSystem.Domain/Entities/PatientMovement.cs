using DiabeticsSystem.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiabeticsSystem.Domain.Entities
{
    public class PatientMovement :AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid DoctorId { get; set; }
        public string? Barcode { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = default!;

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = default!;

        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; } = default!;
    }
}
