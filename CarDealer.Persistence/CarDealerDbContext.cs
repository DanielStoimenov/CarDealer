using CarDealer.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarDealer.Persistence
{
    public partial class CarDealerDbContext : DbContext
    {
        public CarDealerDbContext()
        {
        }

        public CarDealerDbContext(DbContextOptions<CarDealerDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Part> Parts { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasMany(d => d.Parts)
                    .WithMany(p => p.Cars)
                    .UsingEntity<Dictionary<string, object>>(
                        "PartCar",
                        l => l.HasOne<Part>().WithMany().HasForeignKey("PartId"),
                        r => r.HasOne<Car>().WithMany().HasForeignKey("CarId"),
                        j =>
                        {
                            j.HasKey("CarId", "PartId");

                            j.ToTable("PartCars");

                            j.HasIndex(new[] { "PartId" }, "IX_PartCars_PartId");
                        });
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.HasIndex(e => e.SupplierId, "IX_Parts_SupplierId");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Parts)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasIndex(e => e.CarId, "IX_Sales_CarId");

                entity.HasIndex(e => e.CustomerId, "IX_Sales_CustomerId");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CarId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
