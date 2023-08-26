using CarRent.ContractManagement.Domain;
using Microsoft.Identity.Client;

namespace CarRent.ContractManagement.Api.Models
{
    public record RentContractRequest
    (
        Guid Id,
        Reservation Reservation
        );
}
