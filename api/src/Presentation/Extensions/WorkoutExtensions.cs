//using Domain.Common.Entities;
//using Application.DTOs;

//namespace Infrastructure.Extensions
//{
//    public static class WorkoutExtensions
//    {
//        public static List<WorkoutDto> ToDtos(this List<IWorkout> entities)
//        {
//            return entities.Select(ToDto).ToList();
//        }

//        public static WorkoutDto ToDto(this IWorkout entity)
//        {
//            return new WorkoutDto
//            {
//                ID = entity.ID,
//                CreationDate = entity.CreationDate,
//                AccesibilityLevel = entity.AccesibilityLevel,
//                Exercises = entity.Exercises.ToDtos()
//            };
//        }
//    }
//}
