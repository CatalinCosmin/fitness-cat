using Core.Abstractions.Entities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    internal static class WorkoutExtensions
    {
        internal static IWorkout ToModel(this Infrastructure.Entities.Workout entity)
        {
            return new Core.Entities.Workout
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                AccesibilityLevel = entity.AccesibilityLevel,
                CreationDate = entity.CreationDate,
                Exercises = entity.Exercises.ToModelsSimple(),
                Owner = entity.Owner.ToModelSimple(),
                WorkoutRoutine = entity.WorkoutRoutine.ToModelsSimple()
            };
        }

        internal static List<IWorkout> ToModels(this List<Infrastructure.Entities.Workout> entities)
        {
            return entities.Select(e => e.ToModel()).ToList();
        }

        internal static IWorkout ToModelSimple(this Infrastructure.Entities.Workout entity)
        {
            return new Core.Entities.Workout
            {
                ID = entity.ID,
                Name = entity.Name,
                Description = entity.Description,
                AccesibilityLevel = entity.AccesibilityLevel,
                CreationDate = entity.CreationDate,
                Exercises = entity.Exercises.ToModelsSimple()
            };
        }

        internal static List<IWorkout> ToModelsSimple(this List<Infrastructure.Entities.Workout> entities)
        {
            return entities.Select(e => e.ToModelSimple()).ToList();
        }

    }
}
