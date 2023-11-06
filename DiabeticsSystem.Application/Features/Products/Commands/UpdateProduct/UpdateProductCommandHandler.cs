using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using DiabeticsSystem.Domain.Entities;
using MediatR;

namespace DiabeticsSystem.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var objToUpdate = await _unitOfWork.Product.GetAsync(x => x.Id == request.Id)
                ?? throw new Exceptions.NotFoundException(nameof(Product), request.Id);

            var validator = new UpdateProductCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var product = _mapper.Map<Product>(request);

            await _unitOfWork.Product.UpdateAsync(product, Save: true);
        }
    }
}
