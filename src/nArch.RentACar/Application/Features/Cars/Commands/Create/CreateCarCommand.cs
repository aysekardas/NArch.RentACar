using Application.Features.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Create;
public class CreateCarCommand : IRequest<CreatedCarResponse>
{
    public Guid ColorId { get; set; }

    public Guid ModelId { get; set; }

    public string CarState { get; set; }

    public string Kilometer { get; set; }

    public short ModelYear { get; set; }

    public string Plate { get; set; }


    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CreatedCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;
        private readonly CarBusinessRules _carBusinessRules;
        public CreateCarCommandHandler(IMapper mapper, CarBusinessRules carBusinessRules, ICarRepository carRepository)
        {
            _mapper = mapper;
            _carBusinessRules = carBusinessRules;
            _carRepository = carRepository;
        }

        public async Task<CreatedCarResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            Car car = _mapper.Map<Car>(request);

            Car addedCar = await _carRepository.AddAsync(car);

            CreatedCarResponse createdCarResponse = _mapper.Map<CreatedCarResponse>(addedCar);
            return createdCarResponse;
        }
    }
}
