using Domain.Entities;
using NArchitecture.Core.Application.Responses;

namespace Application.Features.Cars.Commands.Update;

public class UpdatedCarResponse : IResponse
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