using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Models.Queries.GetList;

public class GetListModelListItemDto : IDto
{
    public Guid Id { get; set; }
    public short Year { get; set; }
    public decimal DailyPrice { get; set; }
    public Guid BrandId { get; set; }
    public Guid FuelId { get; set; }
    public Guid TransmissionId { get; set; }
}