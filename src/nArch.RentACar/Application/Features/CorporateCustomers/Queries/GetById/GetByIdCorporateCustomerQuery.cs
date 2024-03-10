using Application.Features.CorporateCustomers.Constants;
using Application.Features.CorporateCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.CorporateCustomers.Constants.CorporateCustomersOperationClaims;

namespace Application.Features.CorporateCustomers.Queries.GetById;

public class GetByIdCorporateCustomerQuery : IRequest<GetByIdCorporateCustomerResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdCorporateCustomerQueryHandler : IRequestHandler<GetByIdCorporateCustomerQuery, GetByIdCorporateCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly CorporateCustomerBusinessRules _corporateCustomerBusinessRules;

        public GetByIdCorporateCustomerQueryHandler(IMapper mapper, ICorporateCustomerRepository corporateCustomerRepository, CorporateCustomerBusinessRules corporateCustomerBusinessRules)
        {
            _mapper = mapper;
            _corporateCustomerRepository = corporateCustomerRepository;
            _corporateCustomerBusinessRules = corporateCustomerBusinessRules;
        }

        public async Task<GetByIdCorporateCustomerResponse> Handle(GetByIdCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            CorporateCustomer? corporateCustomer = await _corporateCustomerRepository.GetAsync(predicate: cc => cc.Id == request.Id, cancellationToken: cancellationToken);
            await _corporateCustomerBusinessRules.CorporateCustomerShouldExistWhenSelected(corporateCustomer);

            GetByIdCorporateCustomerResponse response = _mapper.Map<GetByIdCorporateCustomerResponse>(corporateCustomer);
            return response;
        }
    }
}