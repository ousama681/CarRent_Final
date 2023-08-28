namespace CarRent.CarManagement.Api.Models
{
    public record CarClassResponse
    (
        Guid? Id,
        string Name,
        int DailyCost
    );
}
