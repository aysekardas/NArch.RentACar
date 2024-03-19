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

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommand : IRequest<CreatedRentalResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest
{
    public Guid CustomerID { get; set; }
    public Guid CarID { get; set; }
    public string TotalCost { get; set; }
    public DateTime RentStartDate { get; set; }
    public DateTime RentEndDate { get; set; }

    public string[] Roles => [Admin, Write, RentalsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetRentals"];

    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, CreatedRentalResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRentalRepository _rentalRepository;
        private readonly RentalBusinessRules _rentalBusinessRules;

        public CreateRentalCommandHandler(IMapper mapper, IRentalRepository rentalRepository,
                                         RentalBusinessRules rentalBusinessRules)
        {
            _mapper = mapper;
            _rentalRepository = rentalRepository;
            _rentalBusinessRules = rentalBusinessRules;
        }

        public async Task<CreatedRentalResponse> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            Rental rental = _mapper.Map<Rental>(request);

            await _rentalRepository.AddAsync(rental);

            CreatedRentalResponse response = _mapper.Map<CreatedRentalResponse>(rental);
            return response;
        }
    }
}