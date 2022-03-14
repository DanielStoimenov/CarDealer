using System.ComponentModel.DataAnnotations;

namespace CarDealer.Services.Models.Cars.InputModels
{
    public class AddCarInputServiceModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Make { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Model { get; set; }

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }
    }
}
