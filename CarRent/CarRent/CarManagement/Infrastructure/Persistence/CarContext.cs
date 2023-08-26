using CarRent.CarManagement.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarRent.CarManagement.Infrastructure.Persistence
{
    public class CarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-PMVN625; Database=CarRent; Trusted_Connection=true; Encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasOne(c => c.Model)
                .WithMany(m => m.Cars)
                .HasForeignKey(c => c.ModelId);

            modelBuilder.Entity<Model>()
                .HasOne(m => m.Brand)
                .WithMany(b => b.Models)
                .HasForeignKey(m => m.BrandId);

            modelBuilder.Entity<Model>()
                .HasOne(m => m.CarClass)
                .WithMany(c => c.Models)
                .HasForeignKey(m => m.CarClassId);

            modelBuilder.Entity<Brand>()
                .HasMany(b => b.Models)
                .WithOne(m => m.Brand)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarClass>()
                .HasMany(c => c.Models)
                .WithOne(m => m.CarClass)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>()
                .HasMany(c => c.Reservations)
                .WithOne(r => r.Car)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Model> Model { get; set; }
        public DbSet<CarClass> CarClass { get; set; }
    }
}
