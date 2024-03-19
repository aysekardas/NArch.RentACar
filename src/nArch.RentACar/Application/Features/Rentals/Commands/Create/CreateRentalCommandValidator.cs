using FluentValidation;

namespace Application.Features.Rentals.Commands.Create;

public class CreateRentalCommandValidator : AbstractValidator<CreateRentalCommand>
{
    public CreateRentalCommandValidator()
    {
        RuleFor(c => c.CustomerID).NotEmpty();
        RuleFor(c => c.CarID).NotEmpty();
        RuleFor(c => c.TotalCost).NotEmpty();
        RuleFor(c => c.RentStartDate).NotEmpty();
        RuleFor(c => c.RentEndDate).NotEmpty();
    }
}