using CarRent.CarManagement.Api.Models;
using CarRent.CarManagement.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            _repository = repository;
        }


        // GET: api/<CarController>
        [HttpGet]
        public IEnumerable<CarResponse> Get()
        {
            var cars = _repository.GetAll();
            return cars.Select(c => new CarResponse(c.Id, c.Model));
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public CarResponse Get(Guid id)
        {
            return null;
        }

        // GET api/<CarController>/5
        [HttpGet("{modelName, brandName}")]
        public CarResponse Get(string modelName, string brandName)
        {
            return _repository.Get(modelName, brandName);
        }

        // POST api/<CarController>
        [HttpPost]
        public CarResponse Post([FromBody] CarRequest value)
        {
            bool isCarClassExisting = _repository.IsCarClassExisting(value.Model.CarClass.Name);

            if (!isCarClassExisting)
            {
                _repository.AddCarClass(value.Model.CarClass.Name, value.Model.CarClass.DailyCost);
            }

            CarClass carClass = _repository.GetCarClass(value.Model.CarClass.Name, value.Model.CarClass.DailyCost);

            bool isBrandExisting = _repository.IsBrandExisting(value.Model.Brand.Name);

            if (!isBrandExisting)
            {
                _repository.AddBrand(value.Model.Brand.Name);
            }

            Brand brand = _repository.getBrand(value.Model.Brand.Name);

            bool isModelExisting = _repository.IsModelExisting(value.Model.Name, value.Model.Brand.Name);

            if (!isModelExisting)
            {
                _repository.AddModel(value.Model.Name, brand.Id, carClass.Id);
            }

            Model model = _repository.GetModel(value.Model.Name, brand.Id);

            var car = new Car() { Id = Guid.NewGuid(), Model = model };

            _repository.Add(car);

            return new CarResponse(car.Id, car.Model);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] CarRequest value)
        {
            _repository.Edit(id, value);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
