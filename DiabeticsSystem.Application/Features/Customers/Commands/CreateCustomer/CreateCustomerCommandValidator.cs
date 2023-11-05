using DiabeticsSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace DiabeticsSystem.Application.Features.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandValidator(IUnitOfWork unitOfWork)
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
               .MustAsync(CustomerNameUnique)
               .WithMessage("A customer with the same name already exists.");
        }

        private async Task<bool> CustomerNameUnique(CreateCustomerCommand e, CancellationToken token)
        {
            var replica = await _unitOfWork.Customer.GetAsync(x => x.Name == e.Name);
            if (replica is not null)
            {
                return true;
            }
            return false;
        }
    }
}
