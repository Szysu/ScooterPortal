using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Repairs.UpdateRepair;

public class UpdateRepairRequestValidator : Validator<UpdateRepairRequest>
{
    public UpdateRepairRequestValidator()
    {
        RuleFor(x => x.Reason)
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.StartDate)
            .NotEmpty();

        RuleFor(x => x.EndDate)
            .GreaterThan(x => x.StartDate);
    }
}