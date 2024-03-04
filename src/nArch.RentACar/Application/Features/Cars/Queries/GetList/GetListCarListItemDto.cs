using Domain.Entities;
using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Cars.Queries.GetList;

public class GetListCarListItemDto : IDto
{
    public Guid Id { get; set; }
    public Guid ColorId { get; set; }
    public Guid ModelId { get; set; }
    public string CarState { get; set; }
    public string Kilometer { get; set; }
    public short ModelYear { get; set; }
    public string Plate { get; set; }
    public Model? Model { get; set; }
}