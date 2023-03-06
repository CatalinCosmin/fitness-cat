using Application.DTOs;
using Domain.Common.Entities;
using api.Domain.DataTypes;

namespace Application.Common.Interfaces.WorkoutsServices
{
    public interface IWorkoutRoutineService
    {
        Task<bool> DeleteWorkoutRoutineAsync(Guid userId, Guid workoutRoutineId);
        Task<Result<IWorkoutRoutine, string>> GetWorkoutRoutineAsync(Guid userId, Guid id);
        Task<Result<WorkoutRoutineDto, string>> GetWorkoutRoutineDtoAsync(Guid userId, Guid id);
        Task<List<WorkoutRoutineDto>> GetWorkoutRoutineListAsync(Guid userId);
        Task<bool> RemoveWorkoutFromRoutine(Guid userId, Guid routineId, Guid workoutId);
    }
}