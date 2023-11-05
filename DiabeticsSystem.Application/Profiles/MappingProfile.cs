using AutoMapper;
using DiabeticsSystem.Application.Features.Customers.Commands.CreateCustomer;
using DiabeticsSystem.Application.Features.Customers.Commands.UpdateCustomer;
using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerDetails;
using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerList;
using DiabeticsSystem.Domain.Entities;

namespace DiabeticsSystem.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerListVM>().ReverseMap();
            CreateMap<Customer, CustomerDetailsVM>().ReverseMap();
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, UpdateCustomerCommand>().ReverseMap();
        }

    }
}
