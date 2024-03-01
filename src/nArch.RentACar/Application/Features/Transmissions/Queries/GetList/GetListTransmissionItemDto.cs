using Application.Services.Repositories;
using MediatR;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Queries.GetList;
public class GetListTransmissionItemDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}
