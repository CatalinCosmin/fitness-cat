using Application.DTOs;
using Domain.Common.Entities;
using FluentValidation;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace api.Application.Validators
{
    public class RegisterValidator : AbstractValidator<RegisterDto>
    {
        private readonly DataContext _dataContext;
        public RegisterValidator(DataContext dataContext)
        {
            _dataContext = dataContext;
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
                .MustAsync(async (Username, cancellation) =>
            {
                var u = await _dataContext.Users.SingleOrDefaultAsync(u => u.Username == Username);

                return u == null;
            }).WithMessage("Username is already taken.");

            RuleFor(user => user.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email is not of valid format.");
            RuleFor(user => user.Email)
                .MustAsync(async (Email, cancellation) =>
                {
                    var u = await _dataContext.Users.SingleOrDefaultAsync(u => u.Email == Email);

                    return u == null;
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
