using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;

namespace DiabeticsSystem.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateProductCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var @product = _mapper.Map<Product>(request);
            @product = await _unitOfWork.Product.AddAsync(@product, Save: true);

            return @product.Id;
        }
    }
}
