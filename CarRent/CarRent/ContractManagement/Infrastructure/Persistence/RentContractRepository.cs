using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure.Persistence;

namespace CarRent.CarManagement.Infrastructure.Persistence
{
    public class RentContractRepository : IRentContractRepository
    {
        private readonly List<RentContract> _rentContracts;
        private readonly RentContractContext _context;
        public void Add(RentContract car)
        {
            throw new NotImplementedException();
        }

        public RentContract Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RentContract> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(RentContract car)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
