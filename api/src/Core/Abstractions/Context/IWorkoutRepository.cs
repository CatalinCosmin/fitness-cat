using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IWorkoutRepository
    {
        Task<Guid?> CreateWorkoutAsync(Guid userId, List<int> exercisesIDs);
        Task<bool> DeleteWorkoutAsync(Guid userId, Guid workoutId);
        IWorkout? GetWorkout(Guid userId, Guid id);
        Task<IWorkout?> GetWorkoutAsync(Guid userId, Guid id);
        List<IWorkout>? GetWorkoutList(Guid userId);
        Task<List<IWorkout>?> GetWorkoutListAsync(Guid userId);
    }
}