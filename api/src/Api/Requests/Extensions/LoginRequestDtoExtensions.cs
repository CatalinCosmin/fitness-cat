using Core.Abstractions.Entities;
using Core.Entities;

namespace Api.Requests.Extensions
{
    public static class LoginRequestDtoExtensions
    {
        public static IUser ToModel(this LoginRequestDto entity)
        {
            return new User
            {
                ID = Guid.Empty,
                Email = entity.Email,
                Username = entity.Username,
                Password = entity.Password,
                AccountCreationDate = DateOnly.MinValue,
                BirthDate = DateOnly.MinValue,
                isVerified = false,
                LastAuthenticationDate = DateTime.MinValue,
                WorkoutRoutines = new List<IWorkoutRoutine>(),
                Workouts = new List<IWorkout>()
            };
        }
    }
}
