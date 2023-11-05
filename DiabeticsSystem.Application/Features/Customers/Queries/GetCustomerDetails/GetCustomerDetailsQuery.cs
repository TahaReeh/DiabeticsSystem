using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQuery : IRequest<CustomerDetailsVM>
    {
        public Guid Id { get; set; }
    }
}
