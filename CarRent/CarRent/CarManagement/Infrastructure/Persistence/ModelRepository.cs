using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Infrastructure.Persistence
{
    public class ModelRepository : IModelRepository
    {
        private readonly List<Model> _models;
        private readonly CarContext _context;
        public void Add(Model model)
        {
            throw new NotImplementedException();
        }

        public Model Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Model model)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
