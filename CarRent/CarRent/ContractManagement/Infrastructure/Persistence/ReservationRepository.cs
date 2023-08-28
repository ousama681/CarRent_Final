using CarRent.CarManagement.Infrastructure.Persistence;
using CarRent.ContractManagement.Api.Models;
using CarRent.ContractManagement.Domain;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure.Persistence;

namespace CarRent.ContractManagement.Infrastructure.Persistence
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly List<Reservation> _reservations;
        private readonly RentContractContext _context;
        public void Add(Reservation reservation)
        {
            _context.Add(reservation);
            _context.SaveChanges();
        }

        public void Edit(Guid id, ReservationRequest value)
        {
            _context.Update(value);
        }

        public Reservation Get(Guid id)
        {
            return _context.Reservations.Where(r => r.Id.Equals(id)).SingleOrDefault();

        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservations.ToList();
        }

        public void Remove(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
        }

        public void Remove(Guid id)
        {
            Reservation reservation = _context.Reservations.Where(r => r.Id.Equals(id)).SingleOrDefault();
            Remove(reservation);
        }
    }
}
