using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;


namespace Application.Features.Cars.Queries.GetList;
public class GetListCarQuery : IRequest<GetListResponse<GetListCarItemDto>>
{

    public PageRequest PageRequest { get; set; }

    public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, GetListResponse<GetListCarItemDto>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListCarQueryHandler(ICarRepository CarRepository, IMapper mapper)
        {
            _carRepository = CarRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListCarItemDto>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Car> Cars = await _carRepository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize);

            GetListResponse<GetListCarItemDto> response = _mapper.Map<GetListResponse<GetListCarItemDto>>(Cars);

            return response;
        }
    }
}

