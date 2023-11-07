using FluentValidation;

namespace DiabeticsSystem.Application.Features.PatientMovements.Commands.CreatePatientMovement
{
    public class CreatePatientMovementCommandValidatoer : AbstractValidator<CreatePatientMovementCommand>
    {
        public CreatePatientMovementCommandValidatoer()
        {
            RuleFor(u=>u.CustomerId).NotEmpty().NotNull();
            RuleFor(u=>u.ProductId).NotEmpty().NotNull();
        }
    }
}
