using System.ComponentModel.DataAnnotations;

namespace CarDealer.Persistence.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Sales = new HashSet<Sale>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}