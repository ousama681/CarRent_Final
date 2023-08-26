namespace CarRent.CarManagement.Domain
{
    public class Brand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }

        //public Brand(string name)
        //{
        //    Name = name;
        //}
    }
}
