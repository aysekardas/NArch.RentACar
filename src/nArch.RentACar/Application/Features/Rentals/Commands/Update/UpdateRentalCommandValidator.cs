using FluentValidation;

namespace Application.Features.Rentals.Commands.Update;

public class UpdateRentalCommandValidator : AbstractValidator<UpdateRentalCommand>
{
    public UpdateRentalCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerID).NotEmpty();
        RuleFor(c => c.CarID).NotEmpty();
        RuleFor(c => c.TotalCost).NotEmpty();
        RuleFor(c => c.RentStartDate).NotEmpty();
        RuleFor(c => c.RentEndDate).NotEmpty();
    }
}