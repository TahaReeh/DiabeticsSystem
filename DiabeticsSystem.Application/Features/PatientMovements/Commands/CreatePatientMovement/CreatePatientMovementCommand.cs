using MediatR;

namespace DiabeticsSystem.Application.Features.PatientMovements.Commands.CreatePatientMovement
{
    public class CreatePatientMovementCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
        public Guid DoctorId { get; set; }
        public string? Barcode { get; set; }
    }
}
