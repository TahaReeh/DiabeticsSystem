using DiabeticsSystem.Domain.Common;

namespace DiabeticsSystem.Domain.Entities
{
    public class Product : AuditableEntity
    {
        public Guid Id { get; set; }
        public required string Number { get; set; } 
        public required string Name { get; set; }
        public required string Details { get; set; } 
        public required string Code { get; set; }
        public required string Company { get; set; }
    }
}
