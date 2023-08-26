using CarRent.ContractManagement.Domain;

namespace CarRent.CarManagement.Domain
{
    public class RentContract
    {
        public Guid Id { get; set; }
        public Reservation Reservation { get; set; }
        public Guid ReservationId { get; set; }
    }
}
