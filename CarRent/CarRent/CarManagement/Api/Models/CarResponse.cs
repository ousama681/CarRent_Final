using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Api.Models
{
    public record CarResponse(
        Guid Id,
        CarClass CarClass,
        Brand Brand,
        Model Model
    );
}
