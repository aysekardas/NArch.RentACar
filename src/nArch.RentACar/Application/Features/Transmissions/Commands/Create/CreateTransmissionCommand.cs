using Application.Features.Transmissions.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.Create;
public class CreateTransmissionCommand : IRequest<CreatedTransmissionResponse>
{
    public string Name { get; set; }


    public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreatedTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;
        private readonly TransmisisonBusinessRules _transmisisonBusinessRules;
        public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper, TransmisisonBusinessRules transmisisonBusinessRules)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
            _transmisisonBusinessRules = transmisisonBusinessRules;
        }

        public async Task<CreatedTransmissionResponse> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
        {

            await _transmisisonBusinessRules.BeAValidTranmissionType(request.Name);
            Transmission transmission = _mapper.Map<Transmission>(request);
           
            Transmission addedTransmission = await _transmissionRepository.AddAsync(transmission);


            CreatedTransmissionResponse createTransmissionResponse = _mapper.Map<CreatedTransmissionResponse>(addedTransmission);

            return createTransmissionResponse;
        }
    }
}
