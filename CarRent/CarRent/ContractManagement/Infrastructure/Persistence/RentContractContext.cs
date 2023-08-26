using CarRent.CarManagement.Domain;
using CarRent.ContractManagement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace CarRent.CarManagement.Infrastructure.Persistence
{
    public class RentContractContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-PMVN625; Database=CarRent; Trusted_Connection=true; Encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RentContract>()
                .HasOne(r => r.Reservation)
                .WithOne(res => res.RentContract)
                .HasForeignKey<RentContract>(r => r.ReservationId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CarId);
        }

        public DbSet<RentContract> RentContracts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
