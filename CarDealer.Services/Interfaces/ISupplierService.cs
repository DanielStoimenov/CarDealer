using CarDealer.Persistence.Entities;
using CarDealer.Services.Models.Supplier.OutputModels;

namespace CarDealer.Services.Interfaces
{
    public interface ISupplierService
    {
        ICollection<ListAllSupplierPartsServiceModel> GetAllParts(string supplier);

        ICollection<ListAllSuppliersViewModel> GetAllSuppliers();
    }
}