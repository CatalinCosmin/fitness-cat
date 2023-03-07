using FluentValidation;
using Microsoft.IdentityModel.Tokens;

namespace Core.Services.Validators
{
    public class LoginValidator : AbstractValidator<IUser>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Password)
                .NotEmpty();
            RuleFor(x => x.Email)
                .Empty()
                .When(x => x.Username != string.Empty)
                .WithMessage("Insert only username or email.")
                .OverridePropertyName("Meta");
            RuleFor(x => x.Username)
                .Empty()
                .When(x => x.Email != string.Empty)
                .WithMessage("Insert only username or email.")
                .OverridePropertyName("Meta")
                .Matches("^[A-Za-z0-9]*$");
            RuleFor(x => x.WorkoutRoutines)
                .Empty();
            RuleFor(x => x.Workouts)
                .Empty();
        }
    }
}
