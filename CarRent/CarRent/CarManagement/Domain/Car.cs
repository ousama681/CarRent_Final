using CarRent.ContractManagement.Domain;
using System.Text.Json.Serialization;

namespace CarRent.CarManagement.Domain
{
    public class Car
    {
        public Guid Id { get; set; }
        public Model Model { get; set; }
        public Guid ModelId { get; set; }
        [JsonIgnore]
        public List<Reservation> Reservations { get; set; }
    }
}
