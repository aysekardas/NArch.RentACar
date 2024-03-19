using Application.Features.Rentals.Constants;
using Application.Features.Rentals.Constants;
using Application.Features.Rentals.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using MediatR;
using static Application.Features.Rentals.Constants.RentalsOperationClaims;

namespace Application.Features.Rentals.Commands.Delete;

public class DeleteRentalCommand : IRequest<DeletedRentalResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, RentalsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRentals"];

    public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, DeletedRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public DeleteRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository,
                                         RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<DeletedRentalResponse> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            Rental? rental = await _rentalRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalBusinessRules.RentalShouldExistWhenSelected(rental);

            await _rentalRepository.DeleteAsync(rental!);

            DeletedRentalResponse response = _mapper.Map<DeletedRentalResponse>(rental);
            return response;
        }
    }
}