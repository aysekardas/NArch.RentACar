using NArchitecture.Core.Application.Dtos;

namespace Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
}