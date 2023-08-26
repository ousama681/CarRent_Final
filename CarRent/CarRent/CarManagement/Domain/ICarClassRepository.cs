namespace CarRent.CarManagement.Domain
{
    public interface ICarClassRepository
    {
        IEnumerable<CarClass> GetAll();

        CarClass Get(Guid id);

        void Add(CarClass carClass);

        void Remove(CarClass carClass);

        void Remove(Guid id);
    }
}
