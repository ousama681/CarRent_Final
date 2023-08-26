using CarRent.CustomerManagement.Domain;

namespace CarRent.CarManagement.Domain
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();

        Car Get(Guid id);

        void Add(Car car);

        void Remove(Car car);

        void Remove(Guid id);

        bool IsModelExisting(string modelName, string brandName);
        bool IsBrandExisting(string brandName);
        void AddBrand(string brandName);
        void AddModel(string modelName, Guid brandId, Guid carClassId);
        Model GetModel(string modelName, Guid brandId);
        bool IsCarClassExisting(string carClassName);
        void AddCarClass(string carClassName, int dailyCost);
        CarClass GetCarClass(string carClassName, int dailyCost);
        Brand getBrand(string brandName);
    }
}
