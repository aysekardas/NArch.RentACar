using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Rules;
public class TransmisisonBusinessRules : BaseBusinessRules
{
    private readonly ITransmissionRepository _transmissionRepository;

    public TransmisisonBusinessRules(ITransmissionRepository transmissionRepository)
    {
        _transmissionRepository = transmissionRepository;
    }

    public async Task BeAValidTranmissionType(string name)
    {
        var validTransmissionType = new List<string> { "Automatic", "Manual", "Semi-Automatic" };

        if (!validTransmissionType.Contains(name, StringComparer.OrdinalIgnoreCase))
       {
            throw new BusinessException("Geçersiz transmission tipi.");
       }
    }
}
