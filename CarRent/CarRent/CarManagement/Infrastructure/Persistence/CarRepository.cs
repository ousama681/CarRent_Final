using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure.Persistence;
using System.Security.Cryptography.Xml;

namespace CarRent.CarManagement.Infrastructure.Persistence
{
    public class CarRepository : ICarRepository
    {
        private readonly List<Car> _car;
        private readonly CarContext _context;

        public CarRepository(CarContext context)
        {
            _context = context;
        }

        public void Add(Car car)
        {
            _context.Car.Add(car);
            _context.SaveChanges();
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

        public bool IsModelExisting(string modelName, string brandName)
        {
            Model model = _context.Model.Where(m => m.Name.Equals(modelName) && m.Brand.Name.Equals(brandName)).SingleOrDefault();

            if (model != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool IsCarClassExisting(string carClassName)
        {
            CarClass carClass = _context.CarClass.Where(c => c.Name.Equals(carClassName)).SingleOrDefault();

            if (carClass != null)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool IsBrandExisting(string brandName)
        {
            Brand brand = _context.Brand.Where(b => b.Name.Equals(brandName)).SingleOrDefault();

            if (brand != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddCarClass(string carClassName, int dailyCost)
        {
            _context.CarClass.Add(new CarClass() { Id = Guid.NewGuid(), Name = carClassName, DailyCost = dailyCost});
            _context.SaveChanges();
        }

        public void AddBrand(string brandName)
        {
            _context.Brand.Add(new Brand() { Id = Guid.NewGuid(), Name = brandName });
            _context.SaveChanges();
        }


        public Model GetModel(string modelName, Guid brandId)
        {
            return _context.Model.Where(m => m.Name.Equals(modelName) && m.BrandId.Equals(brandId)).SingleOrDefault();
        }

        public void AddModel(string modelName, Guid brandId, Guid carClassId)
        {
            Model model = new Model() { Name = modelName, BrandId = brandId, CarClassId = carClassId };
            _context.Model.Add(model);
            _context.SaveChanges();
        }

        public CarClass GetCarClass(string carClassName, int dailyCost)
        {
            return _context.CarClass.Where(c => c.Name.Equals(carClassName) && c.DailyCost == dailyCost).SingleOrDefault();
        }

        public Brand getBrand(string brandName)
        {
            return _context.Brand.Where(b => b.Name.Equals(brandName)).SingleOrDefault();
        }
    }
}
