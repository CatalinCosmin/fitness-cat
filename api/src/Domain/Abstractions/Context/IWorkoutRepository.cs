using Core.Entities;

namespace Core.Abstractions.Context
{
    public interface IWorkoutRepository
    {
        Task<IWorkout?> GetAsync(int id);
    }
}