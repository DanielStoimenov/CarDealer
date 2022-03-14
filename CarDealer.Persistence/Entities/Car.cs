using System.ComponentModel.DataAnnotations;

namespace CarDealer.Persistence.Entities
{
    public partial class Car
    {
        public Car()
        {
            Sales = new HashSet<Sale>();
            Parts = new HashSet<Part>();
        }

        [Key]
        public int Id { get; set; }

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

        public virtual ICollection<Sale> Sales { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
