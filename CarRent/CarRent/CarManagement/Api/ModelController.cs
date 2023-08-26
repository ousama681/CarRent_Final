using CarRent.CarManagement.Api.Models;
using CarRent.CarManagement.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.CarManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IModelRepository _repository;

        public ModelController(IModelRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);


            _repository = repository;
        }

        // GET: api/<ModelController>
        [HttpGet]
        public IEnumerable<ModelResponse> Get()
        {
            return null;
        }

        // GET api/<ModelController>/5
        [HttpGet("{id}")]
        public ModelRequest Get(Guid id)
        {
            return null;
        }

        // POST api/<ModelController>
        [HttpPost]
        public ModelResponse Post([FromBody] ModelRequest value)
        {
            return null;
        }

        // PUT api/<ModelController>/5
        [HttpPut("{id}")]
        public ModelResponse Put(Guid id, [FromBody] ModelRequest value)
        {
            return null;
        }

        // DELETE api/<ModelController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
        }
    }
}
