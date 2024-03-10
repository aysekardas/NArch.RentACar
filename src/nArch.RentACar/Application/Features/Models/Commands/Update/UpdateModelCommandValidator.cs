using FluentValidation;

namespace Application.Features.Models.Commands.Update;

public class UpdateModelCommandValidator : AbstractValidator<UpdateModelCommand>
{
    public UpdateModelCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Year).NotEmpty();
        RuleFor(c => c.DailyPrice).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.FuelId).NotEmpty();
        RuleFor(c => c.TransmissionId).NotEmpty();
    }
}