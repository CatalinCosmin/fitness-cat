using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IEquipmentRepository
    {
        IEquipment? GetEquipment(int id);
    }
}