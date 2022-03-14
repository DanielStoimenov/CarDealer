using System;
using System.Collections.Generic;

namespace CarDealer.Persistence.Entities
{
    public partial class Sale
    {
        public int Id { get; set; }
        public decimal Discount { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
