namespace CarRent.CustomerManagement.Api.Models
{
    public record CustomerResponse(
        Guid Id,
        long CustomerNr,
        string Name,
        string? Address
    );
}
