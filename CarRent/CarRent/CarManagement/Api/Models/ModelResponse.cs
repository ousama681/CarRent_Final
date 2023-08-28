namespace CarRent.CarManagement.Api.Models
{
    public record ModelResponse
   (Guid? Id,
        string Name,
        BrandResponse Brand,
        CarClassResponse CarClass);
}
