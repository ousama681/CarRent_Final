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
            return null;
        }

        // GET api/<CarController>/5
        [HttpGet("{id}")]
        public CarResponse Get(Guid id)
        {
            return null;
        }

        // POST api/<CarController>
        [HttpPost]
        public CarResponse Post([FromBody] CarRequest value)
        {
            bool isCarClassExisting = _repository.IsCarClassExisting(value.CarClassName);

            if (!isCarClassExisting)
            {
                _repository.AddCarClass(value.CarClassName, value.DailyCost);
            }

            CarClass carClass = _repository.GetCarClass(value.CarClassName, value.DailyCost);

            bool isBrandExisting = _repository.IsBrandExisting(value.BrandName);

            if (!isBrandExisting)
            {
                _repository.AddBrand(value.BrandName);
            }

            Brand brand = _repository.getBrand(value.BrandName);

            bool isModelExisting = _repository.IsModelExisting(value.ModelName, value.BrandName);

            if (!isModelExisting)
            {
                _repository.AddModel(value.ModelName, brand.Id, carClass.Id);
            }

            Model model = _repository.GetModel(value.ModelName, brand.Id);

            var car = new Car() { Id = Guid.NewGuid(), Model = model };

            _repository.Add(car);

            return new CarResponse(car.Id, car.Model);
        }

        // PUT api/<CarController>/5
        [HttpPut("{id}")]
        public CarResponse Put(Guid id, [FromBody] CarRequest value)
        {
            return null;
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
