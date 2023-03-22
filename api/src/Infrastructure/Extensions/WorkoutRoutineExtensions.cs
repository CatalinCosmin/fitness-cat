using Core.Abstractions.Entities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    internal static class WorkoutRoutineExtensions
    {
        internal static IWorkoutRoutine ToModel(this Infrastructure.Entities.WorkoutRoutine entity)
        {
            return new Core.Entities.WorkoutRoutine
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                Workouts = entity.Workouts.ToModelsSimple(),
                AccesibilityLevel = entity.AccesibilityLevel,
                Owner = entity.Owner.ToModelSimple()
            };
        }

        internal static List<IWorkoutRoutine> ToModels(this List<Infrastructure.Entities.WorkoutRoutine> entities)
        {
            return entities.Select(e => e.ToModel()).ToList();
        }

        internal static IWorkoutRoutine ToModelSimple(this Infrastructure.Entities.WorkoutRoutine entity)
        {
            return new Core.Entities.WorkoutRoutine
            {
                ID = entity.ID,
                Name = entity.Name,
                AccesibilityLevel = entity.AccesibilityLevel,
                Description = entity.Description,
                Workouts = entity.Workouts.ToModelsSimple()
            };
        }

        internal static List<IWorkoutRoutine> ToModelsSimple(this List<Infrastructure.Entities.WorkoutRoutine> entities)
        {
            return entities.Select(e => e.ToModelSimple()).ToList();
        }
    }
}
