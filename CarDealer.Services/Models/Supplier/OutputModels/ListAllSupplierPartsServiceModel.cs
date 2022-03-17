using CarDealer.Persistence.Entities;

namespace CarDealer.Services.Models.Supplier.OutputModels
{
    public class ListAllSupplierPartsServiceModel
    {
        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}