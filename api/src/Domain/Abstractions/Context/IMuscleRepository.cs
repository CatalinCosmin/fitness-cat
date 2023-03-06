using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IMuscleRepository
    {
        IMuscle? GetMuscle(int id);
        Task<IMuscle?> GetMuscleAsync(int id);
        List<IMuscle>? GetMuscleList(int id);
        Task<List<IMuscle>?> GetMuscleListAsync(int id);
    }
}