using Core.Abstractions.Entities;
using Core.Entities;

namespace Api.Requests.Extensions
{
    public static class RegisterRequestDtoExtensions
    {
        public static IUser ToModel(this RegisterRequestDto entity)
        {
            return new User
            {
                ID = Guid.NewGuid(),
                Username = entity.Username,
                Email = entity.Email,
                AccountCreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                BirthDate = entity.BirthDate,
                isVerified = false,
                LastAuthenticationDate = null,
                Password = entity.Password,
                WorkoutRoutines = new List<IWorkoutRoutine>(),
                Workouts = new List<IWorkout>()
            };
        }
    }
}
