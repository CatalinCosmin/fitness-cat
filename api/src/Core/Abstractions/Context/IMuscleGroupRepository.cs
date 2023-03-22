using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IMuscleGroupRepository
    {
        IMuscleGroup? GetMuscleGroup(int id);
        Task<IMuscleGroup?> GetMuscleGroupAsync(int id);
        List<IMuscleGroup>? GetMuscleGroupList();
        Task<List<IMuscleGroup>?> GetMuscleGroupListAsync();
    }
}