using CarRent.CarManagement.Domain;
using CarRent.ContractManagement.Api.Models;

namespace CarRent.ContractManagement.Domain
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();

        Reservation Get(Guid id);

        void Add(Reservation reservation);

        void Remove(Reservation reservation);

        void Remove(Guid id);
        void Edit(Guid id, ReservationRequest value);
    }
}
