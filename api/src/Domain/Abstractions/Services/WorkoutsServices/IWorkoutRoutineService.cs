using api.Domain.DataTypes;

namespace Core.Abstractions.Services.WorkoutsServices
{
    public interface IWorkoutRoutineService
    {
        Task<bool> DeleteWorkoutRoutineAsync(Guid userId, Guid workoutRoutineId);
        Task<Result<IWorkoutRoutine, string>> GetWorkoutRoutineAsync(Guid userId, Guid id);
        Task<Result<IWorkoutRoutine, string>> GetWorkoutRoutineDtoAsync(Guid userId, Guid id);
        Task<List<IWorkoutRoutine>> GetWorkoutRoutineListAsync(Guid userId);
        Task<bool> RemoveWorkoutFromRoutine(Guid userId, Guid routineId, Guid workoutId);
    }
}