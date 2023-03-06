using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IMuscleGroupRepository
    {
        IMuscleGroup? GetMuscleGroup(int id);
        List<IMuscleGroup>? GetMuscleGroupList();
    }
}