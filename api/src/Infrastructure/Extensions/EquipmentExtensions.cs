using Core.Abstractions.Entities;

namespace Infrastructure.Extensions
{
    internal static class EquipmentExtensions
    {
        internal static IEquipment ToModel(this Infrastructure.Entities.Equipment entity)
        {
            return new Core.Entities.Equipment
            {
                ID = entity.ID,
                Exercises = entity.Exercises.ToModelsSimple(),
                Name = entity.Name,
            };
        }

        internal static IEquipment ToModelSimple(this Infrastructure.Entities.Equipment entity)
        {
            return new Core.Entities.Equipment
            {
                ID = entity.ID,
                Name = entity.Name,
            };
        }

        internal static List<IEquipment> ToModelsSimple(this List<Infrastructure.Entities.Equipment> entities)
        {
            return entities.Select(e => e.ToModelSimple()).ToList();
        }

        internal static List<IEquipment> ToModels(this List<Infrastructure.Entities.Equipment> entities)
        {
            return entities.Select(e => e.ToModel()).ToList();
        }

    }
}
