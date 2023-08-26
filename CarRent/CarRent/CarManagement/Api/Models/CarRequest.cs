using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Api.Models
{
    public record CarRequest
   (
        Guid Id,
        CarClass CarClass,
        Brand Brand,
        Model Model
    );
}
