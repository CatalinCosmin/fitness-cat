//using Domain.Common.Entities;
//using Application.DTOs;

//namespace Infrastructure.Extensions
//{
//    public static class MuscleExtensions
//    {
//        public static List<MuscleDto> ToDtos(this List<IMuscle> entities)
//        {
//            return entities.Select(ToDto).ToList();
//        }

//        public static MuscleDto ToDto(this IMuscle entity)
//        {
//            return new MuscleDto
//            {
//                ID = entity.ID,
//                Name = entity.Name
//            };
//        }
//    }
//}
