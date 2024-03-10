using NArchitecture.Core.Application.Responses;

namespace Application.Features.CorporateCustomers.Commands.Create;

public class CreatedCorporateCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string CompanyName { get; set; }
    public string TaxNo { get; set; }
}