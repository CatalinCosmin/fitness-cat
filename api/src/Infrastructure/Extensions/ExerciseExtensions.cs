using Core.Abstractions.Entities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    internal static class ExerciseExtensions
    {
        internal static IExercise ToModel(this Infrastructure.Entities.Exercise entity)
        {
            return new Core.Entities.Exercise
            {
                ID = entity.ID,
                Description = entity.Description,
                Difficulty = entity.Difficulty,
                Equipments = entity.Equipments.ToModelsSimple(),
                MuscleGroups = entity.MuscleGroups.ToModelsSimple(),
                Muscles = entity.Muscles.ToModelsSimple(),
                Name = entity.Name,
                Workouts = entity.Workouts.ToModelsSimple()
            };
        }

        internal static List<IExercise> ToModels(this List<Infrastructure.Entities.Exercise> entities)
        {
            return entities.Select(e => e.ToModel()).ToList();
        }

        internal static IExercise ToModelSimple(this Infrastructure.Entities.Exercise entity)
        {
            return new Core.Entities.Exercise
            {
                ID = entity.ID,
                Description = entity.Description,
                Difficulty = entity.Difficulty,
                Name = entity.Name,
                MuscleGroups = entity.MuscleGroups.ToModelsSimple()
                
            };
        }

        internal static List<IExercise> ToModelsSimple(this List<Infrastructure.Entities.Exercise> entities)
        {
            return entities.Select(e => e.ToModelSimple()).ToList();
        }

    }
}
