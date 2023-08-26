using CarRent.ContractManagement.Domain;

namespace CarRent.ContractManagement.Api.Models
{
    public record RentContractResponse
        (
        Guid Id,
        Reservation Reservation
        );
}
