using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Scooters.CreateScooter;

public class CreateScooterRequestValidator : Validator<CreateScooterRequest>
{
    public CreateScooterRequestValidator()
    {
        RuleFor(x => x.Model)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Manufacturer)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.BatteryLevel)
            .InclusiveBetween(0, 100);
    }
}