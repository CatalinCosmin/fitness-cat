using Core.Abstractions.Context;
using Core.DataTypes;

namespace Core.Services.Workouts
{
    public class WorkoutService : IWorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IUnitOfWork _unitOfWork;
        public WorkoutService(IWorkoutRepository workoutRepository, IUnitOfWork unitOfWork)
        {
            _workoutRepository = workoutRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> RemoveExerciseFromWorkoutAsync(Guid userId, Guid workoutId, int exerciseId)
        {
            var workout = await _workoutRepository.GetWorkoutAsync(userId, workoutId);

            if (workout == null)
            {
                return false;
            }

            workout.Exercises.RemoveAll(e => e.ID == exerciseId);
            await _unitOfWork.SaveAsync();

            return true;
        }

    }
}
