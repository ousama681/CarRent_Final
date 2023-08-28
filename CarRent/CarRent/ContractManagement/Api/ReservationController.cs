using CarRent.ContractManagement.Api.Models;
using CarRent.ContractManagement.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarRent.ContractManagement.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {

        private readonly IReservationRepository _repository;

        public ReservationController(IReservationRepository reservationRepository)
        {
            this._repository = reservationRepository;
        }

        // GET: api/<ReservationController>
        [HttpGet]
        public IEnumerable<ReservationResponse> Get()
        {
            var reservations = _repository.GetAll();
            return reservations.Select(r => new ReservationResponse(r.Id, r.Car, r.Customer,r.NumberOfDays, r.TotalCost, r.ReservationNr));
        }

        // GET api/<ReservationController>/5
        [HttpGet("{id}")]
        public ReservationResponse Get(Guid id)
        {
            var r = _repository.Get(id);
            return new ReservationResponse(r.Id, r.Car, r.Customer, r.NumberOfDays, r.TotalCost, r.ReservationNr);
        }

        // POST api/<ReservationController>
        [HttpPost]
        public void Post([FromBody] ReservationRequest value)
        {
            Reservation r = new Reservation() {Id = Guid.NewGuid(), CarId = value.Car.Id, CustomerId = value.Customer.Id, NumberOfDays = value.NumberOfDays, TotalCost = value.TotalCost};
            _repository.Add(r);
        }

        // PUT api/<ReservationController>/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] ReservationRequest value)
        {
            _repository.Edit(id, value);
        }

        // DELETE api/<ReservationController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _repository.Remove(id);
        }
    }
}
