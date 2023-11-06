using AutoMapper;
using DiabeticsSystem.Application.Contracts.Persistence;
using MediatR;

namespace DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerListVM>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<CustomerListVM>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customerList = (await _unitOfWork.Customer.GetAllAsync()).OrderBy(x => x.Number);
            return _mapper.Map<List<CustomerListVM>>(customerList);
        }
    }
}
