using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Application.Features.Customers.Commands.CreateCustomer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDoctorCommandValidator(IUnitOfWork unitOfWork)
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
               .WithMessage("A doctor with the same name or personal identity already exists.");
        }

        private async Task<bool> EntityNameUnique(CreateDoctorCommand e, CancellationToken token)
        {
            var replica = await _unitOfWork.Doctor.GetAsync(x => x.Name == e.Name && x.PersonalId == e.PersonalId);
            if (replica is not null)
            {
                return false;
            }
            return true;
        }
    }
}
