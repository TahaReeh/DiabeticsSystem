using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsVM>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProductDetailsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDetailsVM> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            var obj = await _unitOfWork.Product.GetAsync(u => u.Id == request.ProductId);
            return _mapper.Map<ProductDetailsVM>(request);
        }
    }
}
