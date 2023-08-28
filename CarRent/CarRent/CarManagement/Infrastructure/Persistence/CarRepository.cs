using CarRent.CarManagement.Api.Models;
using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;
using CarRent.CustomerManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
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
            return _context.Car.Where(c => c.Id.Equals(id)).SingleOrDefault();
        }

        public IEnumerable<Car> GetAll()
        {
            return _context.Car.Include(c=> c.Model).Include(c=> c.Model.Brand).Include(c=> c.Model.CarClass).ToList();
        }

        public void Remove(Car car)
        {
            _context.Remove(car);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var car= _context.Car.Where(c => c.Id.Equals(id)).SingleOrDefault();

            _context.Remove(car);
            _context.SaveChanges();
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

        public void Edit(Guid id, CarRequest value)
        {
            var car = Get(id);

           
            car.ModelId = (Guid)value.Model.Id;

            _context.Update(car);
            _context.SaveChanges();
        }

        public CarResponse Get(string modelName, string brandName)
        {
            return _context.Car.Where(c => c.Model.Name.Equals(modelName) && c.Model.Brand.Name.Equals(brandName)).Select(c => new CarResponse(c.Id, c.Model)).SingleOrDefault();
        }
    }
}
