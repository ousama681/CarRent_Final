using CarRent.CarManagement.Api.Models;
using CarRent.CarManagement.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _repository;

        public BrandController(IBrandRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            _repository = repository;
        }


        // GET: api/<BrandController>
        [HttpGet]
        public IEnumerable<BrandResponse> Get()
        {
            return null;
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public BrandResponse Get(Guid id)
        {
            return null; ;
        }

        // POST api/<BrandController>
        [HttpPost]
        public BrandResponse Post([FromBody] BrandRequest value)
        {
            return null;
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public BrandResponse Put(Guid id, [FromBody] BrandRequest value)
        {
            return null;
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public BrandResponse Delete(Guid id)
        {
            return null;
        }
    }
}
