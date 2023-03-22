using Core.Abstractions.Entities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    internal static class MuscleGroupsExtensions
    {
        internal static IMuscleGroup ToModel(this Infrastructure.Entities.MuscleGroup entity)
        {
            return new Core.Entities.MuscleGroup
            {
                ID = entity.ID,
                Exercises = entity.Exercises.ToModelsSimple(),
                Muscles = entity.Muscles.ToModelsSimple(),
                Name = entity.Name
            };
        }

        internal static List<IMuscleGroup> ToModels(this List<Infrastructure.Entities.MuscleGroup> entities)
        {
            return entities.Select(e => e.ToModel()).ToList();
        }

        internal static IMuscleGroup ToModelSimple(this Infrastructure.Entities.MuscleGroup entity)
        {
            return new Core.Entities.MuscleGroup
            {
                ID = entity.ID,
                Name = entity.Name
            };
        }

        internal static List<IMuscleGroup> ToModelsSimple(this List<Infrastructure.Entities.MuscleGroup> entities)
        {
            return entities.Select(e => e.ToModelSimple()).ToList();
        }

    }
}
