using CarDealer.Services.Models.Customer.InputModels;
using CarDealer.Services.Models.Customer.OutputModels;

namespace CarDealer.Services.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(AddCustomerInputServiceModel model);

        ICollection<ListAllCustomersServiceModel> GetAll();

        ICollection<ListAllCustomerByNameServiceModel> SearchByName(string name);

        bool RemoveByName(string name);
    }
}