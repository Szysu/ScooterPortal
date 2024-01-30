using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Rentals.CreateRental;

public class CreateRentalRequestValidator : Validator<CreateRentalRequest>
{
    public CreateRentalRequestValidator()
    {
        RuleFor(x => x.ScooterId)
            .NotEmpty();

        RuleFor(x => x.CustomerId)
            .NotEmpty();

        RuleFor(x => x.StartDate)
            .NotEmpty();

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate);
    }
}