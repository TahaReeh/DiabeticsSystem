using DiabeticsSystem.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiabeticsSystem.Domain.Entities
{
    public class Customer : AuditableEntity
    {
        public Guid Id { get; set; }
        public required string Number { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public string? SecondPhone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; } 
        public string? PersonalId { get; set; }
        [Column("BirthDate", TypeName= "date")]
        public DateTime BirthDate { get; set; }
        public int Sex { get; set; }
    }
}
