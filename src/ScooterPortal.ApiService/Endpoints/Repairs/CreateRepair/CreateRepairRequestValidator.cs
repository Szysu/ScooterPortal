using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Repairs.CreateRepair;

public class CreateRepairRequestValidator : Validator<CreateRepairRequest>
{
    public CreateRepairRequestValidator()
    {
        RuleFor(x => x.ScooterId)
            .NotEmpty();

        RuleFor(x => x.Reason)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.StartDate)
            .NotEmpty();

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate);
    }
}