namespace CarDealer.Services.Models.Customer.OutputModels
{
    public class ListAllCustomerByNameServiceModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}