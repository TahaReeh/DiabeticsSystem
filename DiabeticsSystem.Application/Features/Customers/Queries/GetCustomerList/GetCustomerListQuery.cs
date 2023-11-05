using MediatR;

namespace DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQuery : IRequest<List<CustomerListVM>>
    {
    }
}
