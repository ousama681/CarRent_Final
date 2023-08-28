using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Api.Models
{
    public record CarRequest
   (
        Guid? id,
        ModelResponse Model
    );
}
