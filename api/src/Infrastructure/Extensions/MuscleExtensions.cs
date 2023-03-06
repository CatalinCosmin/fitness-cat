using Core.Abstractions.Entities;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Extensions
{
    internal static class MuscleExtensions
    {
        internal static IMuscle ToModel(this Infrastructure.Entities.Muscle entity)
        {
            return new Core.Entities.Muscle
            {
                ID = entity.ID,
                Exercises = entity.Exercises.ToModelsSimple(),
                MuscleGroups = entity.MuscleGroups.ToModelsSimple(),
                Name = entity.Name,
            };
        }

        internal static List<IMuscle> ToModels(this List<Infrastructure.Entities.Muscle> entities)
        {
            return entities.Select(e => e.ToModel()).ToList();
        }

        internal static IMuscle ToModelSimple(this Infrastructure.Entities.Muscle entity)
        {
            return new Core.Entities.Muscle
            {
                ID = entity.ID,
                Name = entity.Name,
            };
        }

        internal static List<IMuscle> ToModelsSimple(this List<Infrastructure.Entities.Muscle> entities)
        {
            return entities.Select(e => e.ToModelSimple()).ToList();
        }

    }
}
