//using Domain.Common.Entities;
//using Application.DTOs;

//namespace Infrastructure.Extensions
//{
//    public static class ExerciseExtensions
//    {
//        public static List<ExerciseDto> ToDtos(this List<Exercise> entities) 
//        {
//            return entities.Select(ToDto).ToList();
//        }

//        public static ExerciseDto ToDto(this Exercise entity )
//        {
//            return new ExerciseDto
//            {
//                ID = entity.ID,
//                Name= entity.Name,
//                Description = entity.Description,
//                Difficulty= entity.Difficulty,
//                MuscleGroups= entity.MuscleGroups.ToDtos(),
//                Muscles = entity.Muscles.ToDtos(),
//                Equipments = entity.Equipments.ToDtos()
//            };
//        }
//    }
//}
