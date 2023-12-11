using DiabeticsSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace DiabeticsSystem.Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDoctorCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Number)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.Phone)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();
            RuleFor(e => e)
                .MustAsync(EntityNameUnique)
                .WithMessage("A doctor with the same name already exists.");
        }

        private async Task<bool> EntityNameUnique(UpdateDoctorCommand e, CancellationToken token)
        {
            var replica = await _unitOfWork.Doctor.GetAsync(x => x.Name == e.Name && x.Id != e.Id);
            if (replica is not null)
            {
                return false;
            }
            return true;
        }
    }
}
