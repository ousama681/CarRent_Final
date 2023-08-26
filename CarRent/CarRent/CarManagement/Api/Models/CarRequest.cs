using CarRent.CarManagement.Domain;

namespace CarRent.CarManagement.Api.Models
{
    public record CarRequest
   (
        string ModelName,
        string BrandName,
        string CarClassName,
        int DailyCost
    );
}
