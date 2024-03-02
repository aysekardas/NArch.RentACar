using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Profiles;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Car, CreateCarCommand>().ReverseMap();
        CreateMap<Car, CreatedCarResponse>().ReverseMap();
        CreateMap<Car, GetListCarItemDto>().ReverseMap();
        CreateMap<IPaginate<Car>, GetListResponse<GetListCarItemDto>>().ReverseMap();
    }
}
