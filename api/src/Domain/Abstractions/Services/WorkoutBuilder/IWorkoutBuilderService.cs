using api.Domain.DataTypes;

namespace Core.Abstractions.Services.WorkoutBuilder
{
    public interface IWorkoutBuilderService
    {
        Task<Result<Guid, string>> CreateWorkoutAsync(Guid userId, List<int> exercises);
        Task<Result<Guid, string>> CreateWorkoutRoutineAsync(Guid userId, List<Guid> workoutIDs);
    }
}