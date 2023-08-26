using CarRent.CustomerManagement.Api.Models;
using CarRent.CustomerManagement.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CarRent.CustomerManagement.Api
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            _repository = repository;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerResponse> Get()
        {
            var customers = _repository.GetAll();
            return customers.Select(x => new CustomerResponse(x.Id, x.CustomerNr, x.Name, x.Address));
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerResponse Get(Guid id)
        {
            return null;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{Customername, Address}")]
        public Guid Get([FromBody] CustomerRequest customerRequest)
        {
            List<Customer> customers = _repository.GetAll().ToList();
            return customers.Where(c => c.Name.Equals(customerRequest.Name) && c.Address.Equals(customerRequest.Address)).Select(c => c.Id).SingleOrDefault();
        }

        // POST api/<CustomerController>
        [HttpPost]
        public CustomerResponse Post([FromBody] CustomerRequest value)
        {
            Customer customer = new Customer() { Name = value.Name, Address = value.Address, CustomerNr = _repository.GetNextCustomerNr()};
            return _repository.Add();
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public CustomerResponse Put(Guid id, [FromBody] CustomerRequest value)
        {
            return null;
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            //sfsfsfsfsfsfsf
        }
    }
}
