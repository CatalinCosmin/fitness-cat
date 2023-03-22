using Core.Abstractions.Context;
using FluentValidation;

namespace Core.Services.Validators
{
    public class RegisterValidator : AbstractValidator<IUser>
    {
        private readonly IUserRepository _userRepository;
        public RegisterValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(user => user.Username)
                .NotEmpty()
                .MinimumLength(6)
                .WithMessage("Username must be between 6 and 12 characters.")
                .MaximumLength(12)
                .WithMessage("Username must be between 6 and 12 characters.")
                .Custom((Username, context) =>
            {
                if (Username.All(char.IsLetterOrDigit) == false)
                {
                    context.AddFailure("Username must contain only letters or digits.");
                }
            });
            RuleFor(user => user.Username)
                .MustAsync(async (Username, token) =>
            {
                var u = await _userRepository.GetUser(username: Username);

                return u is null;
            }).WithMessage("Username is already taken.");

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is not of valid format.");
            RuleFor(user => user.Email)
                .MustAsync(async (Email, token) =>
                {
                    var u = await _userRepository.GetUser(email: Email);

                    return u is null;
                }).WithMessage("Email is already taken.");

            RuleFor(user => user.Password)
                .NotEmpty()
                .MinimumLength(8)
                .WithMessage("Password must have minimum 8 characters.");

            RuleFor(user => user.BirthDate)
                .NotEmpty()
                .WithMessage("Birth date must not be empty.")
                .Custom((BirthDate, context) =>
                {
                    var age = DateTime.UtcNow - BirthDate.ToDateTime(TimeOnly.MinValue);
                    if (age.Days < 1 * 264)
                    {
                        context.AddFailure("IUser doesn't follow age restriction.");
                    }
                });
        }
    }
}
