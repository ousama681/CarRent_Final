using CarRent.ContractManagement.Domain;

namespace CarRent.CarManagement.Domain
{
    public class Car
    {
        public Guid Id { get; set; }
        //public CarClass CarClass { get; set; }
        //public Brand Brand { get; }
        public Model Model { get; set; }
        public Guid ModelId { get; set; }
        public List<Reservation> Reservations { get; set; }

        //public Car(Guid id, CarClass carClass, Brand brand, Model model)
        //{
        //    this.id = id;
        //    CarClass = CarClass;
        //    Brand = brand;
        //    Model = model;
        //}
    }
}
