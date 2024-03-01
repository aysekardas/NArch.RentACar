using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.Create;
public class CreateTransmissionValidator : AbstractValidator<CreateTransmissionCommand>
{

    public CreateTransmissionValidator()
    {
        RuleFor(t => t.Name)
                    .NotEmpty().NotNull();/*.Must(BeAValidTranmissionType);*/
    }

    //public bool BeAValidTranmissionType(string transmission)
    //{
    //    var validTransmissionType = new List<string> { "Automatic", "Manual", "Semi-Automatic" };

    //    return validTransmissionType.Contains(transmission);
    //}
}
