//using Domain.Common.Entities;
//using Application.DTOs;

//namespace Infrastructure.Extensions
//{
//    public static class MuscleGroupExtensions
//    {
//        public static List<MuscleGroupDto> ToDtos(this List<IMuscleGroup> entities)
//        {
//            return entities.Select(ToDto).ToList();
//        }

//        public static MuscleGroupDto ToDto(this IMuscleGroup entity)
//        {
//            return new MuscleGroupDto
//            {
//                ID = entity.ID,
//                Name = entity.Name
//            };
//        }
//    }
//}
