using api.Domain.DataTypes;

namespace Core.Abstractions.Services.WorkoutsServices
{
    public interface IWorkoutService
    {
        Task<Result<IWorkout, string>> GetWorkoutAsync(Guid userId, Guid id);
        Task<List<IWorkout>> GetWorkoutListAsync(Guid userId);
        Task<bool> RemoveExerciseFromWorkoutAsync(Guid userId, Guid workoutId, int exerciseId);
        Task<Result<IWorkoutRoutine, string>> GetWorkoutRoutineAsync(Guid userId, Guid id);
        Task<bool> RemoveWorkoutFromRoutine(Guid userId, Guid routineId, Guid workoutId);
        Task<bool> DeleteWorkoutAsync(Guid userId, Guid workoutId);
        Task<bool> DeleteWorkoutRoutineAsync(Guid userId, Guid routineId);
    }
}