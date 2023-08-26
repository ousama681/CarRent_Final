using CarRent.CarManagement.Infrastructure.Persistence;
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
            throw new NotImplementedException();
        }

        public Reservation Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
