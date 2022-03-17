using AutoMapper;

using CarDealer.Persistence.Entities;
using CarDealer.Services.Models.Cars.InputModels;
using CarDealer.Services.Models.Cars.OutputModels;
using CarDealer.Services.Models.Customer.InputModels;
using CarDealer.Services.Models.Customer.OutputModels;
using CarDealer.Services.Models.Parts.OutputModels;

namespace CarDealer.Mapping
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Cars
            this.CreateMap<Car, ListAllCarsServiceModel>();

            this.CreateMap<Car, ListAllCarsByModelServiceModel>();

            this.CreateMap<Car, ListAllCarsByMakeServiceModel>();

            this.CreateMap<AddCarInputServiceModel, Car>();

            // Customers
            this.CreateMap<Customer, ListAllCustomersServiceModel>();

            this.CreateMap<Customer, ListAllCustomerByNameServiceModel>();

            this.CreateMap<AddCustomerInputServiceModel, Customer>();

            // Parts
            this.CreateMap<Part, ListAllPartsServiceModel>()
                .ForMember(supp => supp.SupplierName, p => p.MapFrom(p => p.Supplier.Name));
        }
    }
}