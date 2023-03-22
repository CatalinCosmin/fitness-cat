using Api.Responses;
using Core.Abstractions.Entities;
using Infrastructure.Entities;

namespace Api.Response.Extensions
{
    public static class WorkoutRoutineExtensions
    {
        public static WorkoutRoutineResponseDto ToResponseDto(this IWorkoutRoutine entity)
        {
            return new WorkoutRoutineResponseDto
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                Workouts = entity.Workouts.ToResponseDtos()
            };
        }

        public static List<WorkoutRoutineResponseDto> ToResponseDtos(this List<IWorkoutRoutine> entities)
        {
            return entities.Select(ToResponseDto).ToList();
        }
    }
}
