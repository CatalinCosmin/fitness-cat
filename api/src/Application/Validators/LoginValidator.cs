using Application.DTOs;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace api.Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty();
            RuleFor(x => x.Email)
                .Null()
                .When(x => x.Username.IsNullOrEmpty() == false)
                .WithMessage("Insert only username or email.")
                .OverridePropertyName("Meta");
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email is not of valid format.");
            RuleFor(x => x.Username)
                .Null()
                .When(x => x.Email.IsNullOrEmpty() == false)
                .WithMessage("Insert only username or email.")
                .OverridePropertyName("Meta");
            RuleFor(x => x.Username)
                .Matches("^[A-Za-z0-9]*$");
        }
    }
}
