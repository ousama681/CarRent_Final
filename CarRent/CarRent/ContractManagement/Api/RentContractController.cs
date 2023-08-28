using CarRent.CarManagement.Domain;
using CarRent.ContractManagement.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.ContractManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentContractController : ControllerBase
    {
        private readonly IRentContractRepository _repository;

        public RentContractController(IRentContractRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<RentContractController>
        [HttpGet]
        public IEnumerable<RentContractResponse> Get()
        {
            var rentcontracts = _repository.GetAll();
            return rentcontracts.Select(r => new RentContractResponse(r.Id, r.Reservation)).ToList();
        }

        // GET api/<RentContractController>/5
        [HttpGet("{id}")]
        public RentContractResponse Get(Guid id)
        {
            var r = _repository.Get(id);

            return new RentContractResponse(r.Id, r.Reservation);
        }

        // POST api/<RentContractController>
        [HttpPost]
        public void Post([FromBody] RentContractRequest value)
        {
            RentContract r = new RentContract() {Id = Guid.NewGuid(), ReservationId = value.Reservation.Id };
            _repository.Add(r);
        }

        // PUT api/<RentContractController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] RentContractRequest value)
        {
            var r = _repository.Get(id);

            r = new RentContract() { Id = value.Id, ReservationId = value.Reservation.Id };

            _repository.Edit(id, r);
            
        }

        // DELETE api/<RentContractController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
