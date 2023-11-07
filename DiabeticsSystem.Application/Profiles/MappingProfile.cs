using AutoMapper;
using DiabeticsSystem.Application.Features.Customers.Commands.CreateCustomer;
using DiabeticsSystem.Application.Features.Customers.Commands.UpdateCustomer;
using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerDetails;
using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerList;
using DiabeticsSystem.Application.Features.PatientMovements.Commands.CreatePatientMovement;
using DiabeticsSystem.Application.Features.PatientMovements.Commands.DeletePatientMovement;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentByCustomer;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList;
using DiabeticsSystem.Application.Features.Products.Commands.CreateProduct;
using DiabeticsSystem.Application.Features.Products.Commands.UpdateProduct;
using DiabeticsSystem.Application.Features.Products.Queries.GetProductDetails;
using DiabeticsSystem.Application.Features.Products.Queries.GetProductList;
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
            CreateMap<Customer, CustomerDTO>().ReverseMap();


            CreateMap<Product, ProductListVM>().ReverseMap();
            CreateMap<Product, ProductDetailsVM>().ReverseMap();
            CreateMap<Product, CreateProductCommand>().ReverseMap();
            CreateMap<Product, UpdateProductCommand>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();

            CreateMap<PatientMovement, PatientMovmentListVM>();
            CreateMap<PatientMovement, PatientMovmentByCustomerVM>();
            CreateMap<PatientMovement, CreatePatientMovementCommand>().ReverseMap();
        }

    }
}
