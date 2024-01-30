using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Rentals.UpdateRental;

public class UpdateRentalRequestValidator : Validator<UpdateRentalRequest>
{
    public UpdateRentalRequestValidator()
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