using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure.Persistence;

namespace CarRent.CarManagement.Infrastructure.Persistence
{
    public class RentContractRepository : IRentContractRepository
    {
        private readonly List<RentContract> _rentContracts;
        private readonly RentContractContext _context;
        public void Add(RentContract rentContract)
        {
            _context.RentContracts.Add(rentContract);
        }

        public void Edit(Guid id, RentContract r)
        {
            _context.Update(r);
            _context.SaveChanges();
        }

        public RentContract Get(Guid id)
        {
            return _context.RentContracts.Where(r => r.Id.Equals(id)).SingleOrDefault(); ;
        }

        public IEnumerable<RentContract> GetAll()
        {
            return _context.RentContracts.ToList();
        }

        public void Remove(RentContract rentContract)
        {
            _context.Remove(rentContract);
        }

        public void Remove(Guid id)
        {
            RentContract rentContract = _context.RentContracts.Where(r => r.Id.Equals(id)).SingleOrDefault();
            _context.RentContracts.Remove(rentContract);        }
    }
}
