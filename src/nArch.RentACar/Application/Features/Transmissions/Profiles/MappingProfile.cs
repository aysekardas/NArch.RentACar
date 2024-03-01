using Application.Features.Transmissions.Queries.GetList;
using Application.Features.Transmissions.Commands.Create;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Transmissions.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
      CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
        CreateMap<Transmission, CreatedTransmissionResponse>().ReverseMap();
        CreateMap<Transmission, GetListTransmissionItemDto>().ReverseMap();
        CreateMap<IPaginate<Transmission>, GetListResponse<GetListTransmissionItemDto>>().ReverseMap();

    }
}