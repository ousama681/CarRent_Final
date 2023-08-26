using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Api.Models
{
    public record CarResponse(
        Guid Id,
        Model Model
    );
}
