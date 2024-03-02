using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Commands.Create;
public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{
    public CreateCarCommandValidator()
    {
        RuleFor(c => c.CarState).NotEmpty().NotNull();
        RuleFor(c => c.ModelYear).NotEmpty().InclusiveBetween((short)1880, short.MaxValue);
        RuleFor(c=> c.CarState).NotEmpty().NotNull();
        RuleFor(c => c.Kilometer).NotEmpty().NotNull().Must(str => int.TryParse(str, out _));
        RuleFor(c => c.Plate).NotNull().NotEmpty();

            //.GreaterThanOrEqualTo(1880);
    }
}
