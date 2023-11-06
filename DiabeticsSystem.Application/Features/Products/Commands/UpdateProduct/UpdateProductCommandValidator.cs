using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Application.Features.Products.Commands.CreateProduct;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandValidator(IUnitOfWork unitOfWork)
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

        private async Task<bool> ProductNameUniqe(UpdateProductCommand e, CancellationToken token)
        {
            var replica = await _unitOfWork.Product.GetAsync(p => p.Name == e.Name && p.Id != e.Id);
            if (replica is not null)
            {
                return false;
            }
            return true;
        }
    }
}
