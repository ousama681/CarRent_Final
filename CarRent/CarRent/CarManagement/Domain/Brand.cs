using System.Text.Json.Serialization;

namespace CarRent.CarManagement.Domain
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Model> Models { get; set; }
    }
}
