using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;

namespace CarRent.ContractManagement.Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Car Car { get; set; }
        public Guid CarId { get; set; }
        public Customer Customer { get; set; }
        public Guid CustomerId { get; set; }
        public int NumberOfDays { get; set; }
        public double TotalCost { get; set; }
        public long ReservationNr { get; set; }
        public RentContract? RentContract { get; set; }

    }
}
