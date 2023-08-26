using CarRent.CarManagement.Domain;
using CarRent.CustomerManagement.Domain;

namespace CarRent.ContractManagement.Api.Models
{
    public record ReservationResponse
        (
                Guid Id,
     Car Car,
     Customer Customer,
     int NumberOfDays,
     double TotalCost,
     long ReservationNr
        );
}
