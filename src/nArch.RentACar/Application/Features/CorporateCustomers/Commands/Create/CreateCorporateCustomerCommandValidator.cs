using FluentValidation;

namespace Application.Features.CorporateCustomers.Commands.Create;

public class CreateCorporateCustomerCommandValidator : AbstractValidator<CreateCorporateCustomerCommand>
{
    public CreateCorporateCustomerCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CompanyName).NotEmpty();
        RuleFor(c => c.TaxNo).NotEmpty();
    }
}