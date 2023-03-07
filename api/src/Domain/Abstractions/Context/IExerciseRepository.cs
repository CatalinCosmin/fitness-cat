using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IExerciseRepository
    {
        Task<IExercise?> GetExerciseAsync(int id);
        IExercise? GetExercise(int id);
        Task<List<IExercise>?> GetExerciseListAsync(int? muscleGroupId = null, int? muscleId = null, int? equipmentId = null, int? difficulty = null);
    }
}