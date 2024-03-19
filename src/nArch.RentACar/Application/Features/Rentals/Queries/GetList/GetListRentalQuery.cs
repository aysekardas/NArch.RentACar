using Application.Features.Rentals.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Rentals.Constants.RentalsOperationClaims;

namespace Application.Features.Rentals.Queries.GetList;

public class GetListRentalQuery : IRequest<GetListResponse<GetListRentalListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListRentals({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetRentals";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListRentalQueryHandler : IRequestHandler<GetListRentalQuery, GetListResponse<GetListRentalListItemDto>>
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly IMapper _mapper;

        public GetListRentalQueryHandler(IRentalRepository rentalRepository, IMapper mapper)
        {
            _rentalRepository = rentalRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListRentalListItemDto>> Handle(GetListRentalQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Rental> rentals = await _rentalRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListRentalListItemDto> response = _mapper.Map<GetListResponse<GetListRentalListItemDto>>(rentals);
            return response;
        }
    }
}