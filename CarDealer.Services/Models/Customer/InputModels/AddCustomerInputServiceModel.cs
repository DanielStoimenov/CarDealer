using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.Models.Customer.InputModels
{
    public class AddCustomerInputServiceModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}