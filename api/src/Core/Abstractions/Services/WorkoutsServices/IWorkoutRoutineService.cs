namespace Core.Abstractions.Services.WorkoutsServices
{
    public interface IWorkoutRoutineService
    {
        Task<bool> RemoveWorkoutFromRoutine(Guid userId, Guid routineId, Guid workoutId);
    }
}