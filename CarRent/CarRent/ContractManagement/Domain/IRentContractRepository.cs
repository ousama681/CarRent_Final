namespace CarRent.CarManagement.Domain
{
    public interface IRentContractRepository
    {
        IEnumerable<RentContract> GetAll();

        RentContract Get(Guid id);

        void Add(RentContract rentContract);

        void Remove(RentContract rentContract);

        void Remove(Guid id);
    }
}
