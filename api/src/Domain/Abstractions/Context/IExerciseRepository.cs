using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IExerciseRepository
    {
        IExercise? GetExercise(int id);
        IExercise? GetExercise(Func<IExercise, bool> predicate);
        Task<List<IExercise>?> GetExerciseListAsync(int? muscleGroupId = null, int? muscleId = null, int? equipmentId = null, int? difficulty = null);
    }
}