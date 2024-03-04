using Application.Features.Brands.Constants;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.Create;
public class CreateBrandCommand : IRequest<CreatedBrandResponse>, ISecuredRequest
{
    public string Name { get; set; }
    public string Logo { get; set; }

    //  public string[] Roles => new string[] { "Brand.Add" };

    //Brand.Update, Brand.Add, Brand.Delete, Brand.General
    public string[] Roles => new string[] { BrandsOperationClaims.Write, BrandsOperationClaims.Create };



    //Inner class :  İç class

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
    {

        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
        private readonly BrandBusinessRules _brandBusinessRules;
        public CreateBrandCommandHandler(IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules, IMapper mapper)
        {
            _brandRepository = brandRepository;
            _brandBusinessRules = brandBusinessRules;
            _mapper = mapper;
        }

        public async Task<CreatedBrandResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandBusinessRules.CarShouldNotExistsWithSameName(request.Name);
            Brand brand = _mapper.Map<Brand>(request);

            Brand addedBrand = await _brandRepository.AddAsync(brand);

            CreatedBrandResponse createdBrandResponse = _mapper.Map<CreatedBrandResponse>(addedBrand);

            return createdBrandResponse;
        }
    }
}
//Manuel mapping
// Brand brand = new();
// brand.Name = request.Name;
// brand.Logo = request.Logo;

//Brand addedBrand = await _brandRepository.AddAsync(brand);

// CreatedBrandResponse createdBrandResponse = new();
// createdBrandResponse.Name = addedBrand.Name;
// createdBrandResponse.Logo = addedBrand.Logo;
// createdBrandResponse.Id = addedBrand.Id;