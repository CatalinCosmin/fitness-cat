using Api.Responses;
using Core.Abstractions.Entities;
using Infrastructure.Entities;

namespace Api.Response.Extensions
{
    public static class ExerciseExtensions
    {
        public static ExerciseResponseDto ToResponseDto(this IExercise entity)
        {
            return new ExerciseResponseDto
            {
                ID= entity.ID,
                Name= entity.Name,
                MuscleGroups = entity.MuscleGroups.ToResponseDtos()
            };
        }

        public static List<ExerciseResponseDto> ToResponseDtos(this List<IExercise> entities)
        {
            return entities.Select(ToResponseDto).ToList();
        }
    }
}
