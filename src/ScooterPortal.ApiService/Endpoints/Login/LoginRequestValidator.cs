using FluentValidation;

namespace ScooterPortal.ApiService.Endpoints.Login;

public class LoginRequestValidator : Validator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .Length(4, 24)
            .WithErrorCode("UsernameLength");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(128)
            .WithErrorCode("PasswordLength");
    }
}