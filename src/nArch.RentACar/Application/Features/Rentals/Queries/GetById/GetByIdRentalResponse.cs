using NArchitecture.Core.Application.Responses;

namespace Application.Features.Rentals.Queries.GetById;

public class GetByIdRentalResponse : IResponse
{
    public Guid Id { get; set; }
    public Guid CustomerID { get; set; }
    public Guid CarID { get; set; }
    public string TotalCost { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }
}