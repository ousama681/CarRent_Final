using System.Text.Json.Serialization;

namespace CarRent.CarManagement.Domain
{
    public class Model
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public Brand Brand { get; set; }
        [JsonIgnore]
        public List<Car> Cars { get; set; }
        public Guid? BrandId { get; set; }
        public CarClass CarClass { get; set; }
        public Guid? CarClassId { get; set; }
    }
}
