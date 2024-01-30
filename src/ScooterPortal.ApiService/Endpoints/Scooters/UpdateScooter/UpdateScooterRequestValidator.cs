using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Scooters.UpdateScooter;

public class UpdateScooterRequestValidator : Validator<UpdateScooterRequest>
{
    public UpdateScooterRequestValidator()
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