using CarRent.CustomerManagement.Domain;

namespace CarRent.CustomerManagement.Infrastructure.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;
        private readonly CustomerContext _context;

        public CustomerRepository(CustomerContext context)
        {
            //_customers = new List<Customer>()
            //{
            //    new("C00001", "Hans", "Rosenackerstrasse 1, 9403, Goldach"),
            //    new("C00002", "Fritz", "Rosenackerstrasse 1, 9403, Goldach")
            //};

            _context = context;
        }

        public void Add(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
        }

        public Customer Get(Guid id)
        {
            return _context.Customers.Where(c => c.Id.Equals(id)).SingleOrDefault();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers.ToList();
        }

        public long GetNextCustomerNr()
        {
            return _context.Customers.Max(x => x.CustomerNr).SingleOrDefault()+1;
        }

        public void Remove(Customer customer)
        {
            _context.Remove(customer);
            _context.SaveChanges();
        }

        public void Remove(Guid id)
        {
            Customer customer = _context.Customers.Where(c => c.Id.Equals(id)).SingleOrDefault();


            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
