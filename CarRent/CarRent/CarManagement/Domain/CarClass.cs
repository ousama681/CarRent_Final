namespace CarRent.CarManagement.Domain
{
    public class CarClass
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DailyCost { get; set; }
        public List<Model> Models { get; set; }
    }
}
