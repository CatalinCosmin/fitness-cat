using Api.Responses;
using Core.Abstractions.Entities;
using Infrastructure.Entities;

namespace Api.Response.Extensions
{
    public static class WorkoutExtensions
    {
        public static WorkoutResponseDto ToResponseDto(this IWorkout entity)
        {
            return new WorkoutResponseDto
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                Exercises = entity.Exercises.ToResponseDtos()
            };
        }

        public static List<WorkoutResponseDto> ToResponseDtos(this List<IWorkout> entities)
        {
            return entities.Select(ToResponseDto).ToList();
        }
    }
}
