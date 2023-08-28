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
            Customer c = _repository.Get(id);
            return new CustomerResponse(c.Id, c.CustomerNr, c.Name, c.Address);
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
            Customer customer = new Customer() {Id = Guid.NewGuid(), Name = value.Name, Address = value.Address, CustomerNr = _repository.GetNextCustomerNr()};
            _repository.Add(customer);

            Customer savedCustomer = _repository.Get(customer.Id);

            return new CustomerResponse(savedCustomer.Id, savedCustomer.CustomerNr, savedCustomer.Name, savedCustomer.Address);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public CustomerResponse Put(Guid id, [FromBody] CustomerRequest value)
        {
            Customer customer = _repository.Get(id);

            customer.Address = value.Address;
            customer.Name = value.Name;

            _repository.Edit(customer);

            return null;
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
