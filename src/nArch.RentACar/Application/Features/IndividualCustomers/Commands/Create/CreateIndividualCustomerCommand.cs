using Application.Features.IndividualCustomers.Constants;
using Application.Features.IndividualCustomers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.IndividualCustomers.Constants.IndividualCustomersOperationClaims;

namespace Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreatedIndividualCustomerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }

    public string[] Roles => [Admin, Write, IndividualCustomersOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIndividualCustomers"];

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreatedIndividualCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

        public CreateIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository,
                                         IndividualCustomerBusinessRules individualCustomerBusinessRules)
        {
            _mapper = mapper;
            _individualCustomerRepository = individualCustomerRepository;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
        }

        public async Task<CreatedIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            IndividualCustomer individualCustomer = _mapper.Map<IndividualCustomer>(request);

            await _individualCustomerRepository.AddAsync(individualCustomer);

            CreatedIndividualCustomerResponse response = _mapper.Map<CreatedIndividualCustomerResponse>(individualCustomer);
            return response;
        }
    }
}