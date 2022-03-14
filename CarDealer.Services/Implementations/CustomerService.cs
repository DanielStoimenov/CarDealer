using AutoMapper;
using AutoMapper.QueryableExtensions;

using CarDealer.Persistence;
using CarDealer.Persistence.Entities;
using CarDealer.Services.Interfaces;
using CarDealer.Services.Models.Customer.InputModels;
using CarDealer.Services.Models.Customer.OutputModels;

namespace CarDealer.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext dbContext;
        private readonly IMapper mapper;

        public CustomerService(CarDealerDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public void AddCustomer(AddCustomerInputServiceModel model)
        {
            try
            {
                Customer customer = mapper.Map<Customer>(model);
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public ICollection<ListAllCustomersServiceModel> GetAll()
        {
            var customers = dbContext
                .Customers
                .ProjectTo<ListAllCustomersServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            return customers;
        }

        public ICollection<ListAllCustomerByNameServiceModel> SearchByName(string name)
        {
            var customers = dbContext
                .Customers
                .Where(c => c.Name.ToLower().Contains(name.ToLower()))
                .ProjectTo<ListAllCustomerByNameServiceModel>(mapper.ConfigurationProvider)
                .ToList();

            return customers;
        }

        public bool RemoveByName(string name)
        {
            var customer = dbContext
                .Customers
                .Where(c => c.Name.ToLower().Equals(name.ToLower()));

            if (customer == null)
            {
                throw new ArgumentException("Customer not found");
            }

            dbContext.Customers.RemoveRange(customer);
            var rowsAffected = dbContext.SaveChanges();

            bool isRemoved = rowsAffected == 1;

            return isRemoved;
        }
    }
}