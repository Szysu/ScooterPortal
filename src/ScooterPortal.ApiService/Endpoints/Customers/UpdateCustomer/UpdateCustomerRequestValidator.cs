using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Customers.UpdateCustomer;

public class UpdateCustomerRequestValidator : Validator<UpdateCustomerRequest>
{
    public UpdateCustomerRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(50);
    }
}