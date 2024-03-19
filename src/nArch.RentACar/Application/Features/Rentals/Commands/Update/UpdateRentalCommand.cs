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

namespace Application.Features.Rentals.Commands.Update;

public class UpdateRentalCommand : IRequest<UpdatedRentalResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid Id { get; set; }
    public Guid CustomerID { get; set; }
    public Guid CarID { get; set; }
    public string TotalCost { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }

    public string[] Roles => [Admin, Write, RentalsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRentals"];

    public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, UpdatedRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public UpdateRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository,
                                         RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<UpdatedRentalResponse> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            Rental? rental = await _rentalRepository.GetAsync(predicate: r => r.Id == request.Id, cancellationToken: cancellationToken);
            await _rentalBusinessRules.RentalShouldExistWhenSelected(rental);
            rental = _mapper.Map(request, rental);

            await _rentalRepository.UpdateAsync(rental!);

            UpdatedRentalResponse response = _mapper.Map<UpdatedRentalResponse>(rental);
            return response;
        }
    }
}