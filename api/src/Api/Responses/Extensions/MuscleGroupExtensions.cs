using Api.Responses;
using Core.Abstractions.Entities;
using Infrastructure.Entities;

namespace Api.Response.Extensions
{
    public static class MuscleGroupsExtensions
    {
        public static MuscleGroupResponseDto ToResponseDto(this IMuscleGroup entity)
        {
            return new MuscleGroupResponseDto
            {
                ID= entity.ID,
                Name= entity.Name
            };
        }

        public static List<MuscleGroupResponseDto> ToResponseDtos(this List<IMuscleGroup> entities)
        {
            return entities.Select(ToResponseDto).ToList();
        }
    }
}
