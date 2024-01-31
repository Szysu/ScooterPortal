using FluentValidation;
using ScooterPortal.Web.Components.Common;

namespace ScooterPortal.Web.Components.Pages.Login;

public record LoginForm
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;
}

public class LoginFormValidator : FormValidator<LoginForm>
{
    public LoginFormValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty()
            .Length(4, 24);

        RuleFor(x => x.Password)
            .NotEmpty()
            .MaximumLength(128);
    }
}