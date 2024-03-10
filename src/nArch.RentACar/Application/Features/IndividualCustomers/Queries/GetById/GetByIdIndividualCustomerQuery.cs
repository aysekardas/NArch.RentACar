using Application.Features.IndividualCustomers.Constants;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.IndividualCustomers.Constants.IndividualCustomersOperationClaims;

namespace Application.Features.IndividualCustomers.Queries.GetById;

public class GetByIdIndividualCustomerQuery : IRequest<GetByIdIndividualCustomerResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdIndividualCustomerQueryHandler : IRequestHandler<GetByIdIndividualCustomerQuery, GetByIdIndividualCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

        public GetByIdIndividualCustomerQueryHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository, IndividualCustomerBusinessRules individualCustomerBusinessRules)
        {
            _mapper = mapper;
            _individualCustomerRepository = individualCustomerRepository;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
        }

        public async Task<GetByIdIndividualCustomerResponse> Handle(GetByIdIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(predicate: ic => ic.Id == request.Id, cancellationToken: cancellationToken);
            await _individualCustomerBusinessRules.IndividualCustomerShouldExistWhenSelected(individualCustomer);

            GetByIdIndividualCustomerResponse response = _mapper.Map<GetByIdIndividualCustomerResponse>(individualCustomer);
            return response;
        }
    }
}