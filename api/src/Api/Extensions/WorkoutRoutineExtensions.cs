//using Domain.Common.Entities;
//using Application.DTOs;

//namespace Infrastructure.Extensions
//{
//    public static class WorkoutRoutineExtensions
//    {
//        public static List<WorkoutRoutineDto> ToDtos(this List<IWorkoutRoutine> entities)
//        {
//            return entities.Select(ToDto).ToList();
//        }

//        public static WorkoutRoutineDto ToDto(this IWorkoutRoutine entity)
//        {
//            return new WorkoutRoutineDto
//            {
//                ID = entity.ID,
//                AccesibilityLevel = entity.AccesibilityLevel,
//                Workouts = entity.Workouts.ToDtos()
//            };
//        }
//    }
//}
