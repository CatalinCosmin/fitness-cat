using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IMuscleRepository
    {
        IMuscle? GetMuscle(int id);
        List<IMuscle>? GetMuscleList(Func<IMuscle, bool> predicate);
        List<IMuscle>? GetMuscleList(int id);
    }
}