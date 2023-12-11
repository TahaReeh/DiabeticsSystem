using AutoMapper;
using DiabeticsSystem.Application.Features.Customers.Commands.CreateCustomer;
using DiabeticsSystem.Application.Features.Customers.Commands.UpdateCustomer;
using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerDetails;
using DiabeticsSystem.Application.Features.Customers.Queries.GetCustomerList;
using DiabeticsSystem.Application.Features.Doctors.Commands.CreateDoctor;
using DiabeticsSystem.Application.Features.Doctors.Commands.UpdateDoctor;
using DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorDetails;
using DiabeticsSystem.Application.Features.Doctors.Queries.GetDoctorList;
using DiabeticsSystem.Application.Features.PatientMovements.Commands.CreatePatientMovement;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentByCustomer;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentExport;
using DiabeticsSystem.Application.Features.PatientMovements.Queries.GetPatientMovmentList;
using DiabeticsSystem.Application.Features.Products.Commands.CreateProduct;
using DiabeticsSystem.Application.Features.Products.Commands.UpdateProduct;
using DiabeticsSystem.Application.Features.Products.Queries.GetProductDetails;
using DiabeticsSystem.Application.Features.Products.Queries.GetProductList;
using DiabeticsSystem.Application.Features.SystemSettings.Commands;
using DiabeticsSystem.Application.Features.SystemSettings.Queries.GetSystemSettings;
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
            CreateMap<PatientMovement, PatientMovementExportDTO>().ReverseMap();

            CreateMap<SystemSetting, SystemSettingsVM>();
            CreateMap<SystemSetting, UpdateSystemSettingsCommand>().ReverseMap();

            CreateMap<Doctor, DoctorListVM>().ReverseMap();
            CreateMap<Doctor, DoctorDetailsVM>().ReverseMap();
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, UpdateDoctorCommand>().ReverseMap();
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
        }

    }
}
