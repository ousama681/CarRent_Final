using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure.Persistence;

namespace CarRent.CarManagement.Infrastructure.Persistence
{
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> _car;
        private readonly CarContext _context;
        public void Add(Car car)
        {
            throw new NotImplementedException();
        }

        public Car Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Car> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Car car)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
