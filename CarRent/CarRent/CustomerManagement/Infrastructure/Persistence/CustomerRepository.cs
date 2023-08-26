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

            throw new NotImplementedException();
        }

        public Customer Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        public void Remove(Customer customer)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
