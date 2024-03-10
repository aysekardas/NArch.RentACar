using FluentValidation;

namespace Application.Features.Models.Commands.Create;

public class CreateModelCommandValidator : AbstractValidator<CreateModelCommand>
{
    public CreateModelCommandValidator()
    {
        RuleFor(c => c.Year).NotEmpty();
        RuleFor(c => c.DailyPrice).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.FuelId).NotEmpty();
        RuleFor(c => c.TransmissionId).NotEmpty();
    }
}