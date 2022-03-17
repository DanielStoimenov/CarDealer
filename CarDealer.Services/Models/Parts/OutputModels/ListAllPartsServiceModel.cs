namespace CarDealer.Services.Models.Parts.OutputModels
{
    public class ListAllPartsServiceModel
    {
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string? SupplierName { get; set; }
    }
}
