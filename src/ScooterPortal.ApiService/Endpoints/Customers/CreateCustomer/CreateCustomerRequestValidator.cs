using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Customers.CreateCustomer;

public class CreateCustomerRequestValidator : Validator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);
    }
}