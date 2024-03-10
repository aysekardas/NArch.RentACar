using Application.Features.IndividualCustomers.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.IndividualCustomers.Constants.IndividualCustomersOperationClaims;

namespace Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQuery : IRequest<GetListResponse<GetListIndividualCustomerListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListIndividualCustomers({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetIndividualCustomers";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, GetListResponse<GetListIndividualCustomerListItemDto>>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public GetListIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListIndividualCustomerListItemDto>> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            IPaginate<IndividualCustomer> individualCustomers = await _individualCustomerRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListIndividualCustomerListItemDto> response = _mapper.Map<GetListResponse<GetListIndividualCustomerListItemDto>>(individualCustomers);
            return response;
        }
    }
}