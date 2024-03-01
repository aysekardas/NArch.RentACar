using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Queries.GetList;
public class GetListTransmissionQuery : IRequest<GetListResponse<GetListTransmissionItemDto>>
{
    public PageRequest PageRequest { get; set; }


    public class GetListTransmissionQueryHandler : IRequestHandler<GetListTransmissionQuery, GetListResponse<GetListTransmissionItemDto>>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public GetListTransmissionQueryHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTransmissionItemDto>> Handle(GetListTransmissionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Transmission> transmissions = await _transmissionRepository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize);

            GetListResponse<GetListTransmissionItemDto> response = _mapper.Map<GetListResponse<GetListTransmissionItemDto>>(transmissions);

            return response;

        }
    }
}
