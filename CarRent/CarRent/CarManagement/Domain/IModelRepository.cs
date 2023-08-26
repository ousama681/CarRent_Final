namespace CarRent.CarManagement.Domain
{
    public interface IModelRepository
    {
        IEnumerable<Model> GetAll();

        Model Get(Guid id);

        void Add(Model model);

        void Remove(Model model);

        void Remove(Guid id);
    }
}
