using Core.Abstractions.Context;

namespace Core.Services.Workouts
{
    public class WorkoutRoutineService : IWorkoutRoutineService
    {
        private readonly IWorkoutRoutineRepository _workoutRoutineRepository;
        private readonly IUnitOfWork _unitOfWork;
        public WorkoutRoutineService(IWorkoutRoutineRepository workoutRoutineRepository, IUnitOfWork unitOfWork)
        {
            _workoutRoutineRepository = workoutRoutineRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> RemoveWorkoutFromRoutine(Guid userId, Guid routineId, Guid workoutId)
        {
            var workoutRoutine = await _workoutRoutineRepository.GetWorkoutRoutineAsync(userId, routineId);

            if (workoutRoutine == null)
            {
                return false;
            }

            workoutRoutine.Workouts.RemoveAll(w => w.ID == workoutId);
            await _unitOfWork.SaveAsync();

            return true;
        }

    }
}
