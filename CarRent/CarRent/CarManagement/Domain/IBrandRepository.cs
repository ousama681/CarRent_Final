namespace CarRent.CarManagement.Domain
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAll();

        Brand Get(Guid id);

        void Add(Brand brand);

        void Remove(Brand brand);

        void Remove(Guid id);
    }
}
