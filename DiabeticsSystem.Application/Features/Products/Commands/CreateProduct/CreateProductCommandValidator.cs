using DiabeticsSystem.Application.Contracts.Persistence;
using FluentValidation;

namespace DiabeticsSystem.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(u => u.Number)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(u => u.Name)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(u => u.Details)
                .NotNull()
                .NotEmpty().WithMessage("{PropertyName} is required.");

            RuleFor(p => p)
                .MustAsync(ProductNameUniqe)
                .WithMessage("A Product with the same name already exists.");
        }

        private async Task<bool> ProductNameUniqe(CreateProductCommand e, CancellationToken token)
        {
            var replica = await _unitOfWork.Product.GetAsync(p => p.Name == e.Name);
            if (replica is not null)
            {
                return false;
            }
            return true;
        }
    }
}
