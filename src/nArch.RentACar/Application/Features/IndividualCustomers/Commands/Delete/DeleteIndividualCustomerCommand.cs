using Application.Features.IndividualCustomers.Constants;
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

namespace Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommand : IRequest<DeletedIndividualCustomerResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, IndividualCustomersOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetIndividualCustomers"];

    public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeletedIndividualCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IndividualCustomerBusinessRules _individualCustomerBusinessRules;

        public DeleteIndividualCustomerCommandHandler(IMapper mapper, IIndividualCustomerRepository individualCustomerRepository,
                                         IndividualCustomerBusinessRules individualCustomerBusinessRules)
        {
            _mapper = mapper;
            _individualCustomerRepository = individualCustomerRepository;
            _individualCustomerBusinessRules = individualCustomerBusinessRules;
        }

        public async Task<DeletedIndividualCustomerResponse> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            IndividualCustomer? individualCustomer = await _individualCustomerRepository.GetAsync(predicate: ic => ic.Id == request.Id, cancellationToken: cancellationToken);
            await _individualCustomerBusinessRules.IndividualCustomerShouldExistWhenSelected(individualCustomer);

            await _individualCustomerRepository.DeleteAsync(individualCustomer!);

            DeletedIndividualCustomerResponse response = _mapper.Map<DeletedIndividualCustomerResponse>(individualCustomer);
            return response;
        }
    }
}