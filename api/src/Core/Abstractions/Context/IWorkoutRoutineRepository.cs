using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IWorkoutRoutineRepository
    {
        Task<Guid?> CreateWorkoutRoutineAsync(Guid userId, List<Guid> workoutIDs);
        Task<bool> DeleteWorkoutRoutineAsync(Guid userId, Guid workoutRoutineId);
        IWorkoutRoutine? GetWorkoutRoutine(Guid userId, Guid id);
        Task<IWorkoutRoutine?> GetWorkoutRoutineAsync(Guid userId, Guid id);
        List<IWorkoutRoutine>? GetWorkoutRoutineList(Guid userId);
        Task<List<IWorkoutRoutine>?> GetWorkoutRoutineListAsync(Guid userId);
    }
}