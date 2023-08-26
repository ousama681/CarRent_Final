using CarRent.ContractManagement.Domain;

namespace CarRent.CustomerManagement.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string CustomerNr { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        //public Customer(string customerNr, string name, string address)
        //{
        //    Id = Guid.NewGuid();
        //    CustomerNr = customerNr;
        //    Name = name;
        //    Address = address;
        //}
    }
}
