using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IWorkoutRoutineRepository
    {
        Task<IWorkout?> GetAsync(int id);
    }
}