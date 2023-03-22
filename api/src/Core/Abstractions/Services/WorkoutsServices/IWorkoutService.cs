namespace Core.Abstractions.Services.WorkoutsServices
{
    public interface IWorkoutService
    {
        Task<bool> RemoveExerciseFromWorkoutAsync(Guid userId, Guid workoutId, int exerciseId);
    }
}