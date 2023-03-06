//using api.Domain.Abstractions.Services.Auth;
//using api.Domain.Abstractions.Services.WorkoutsServices;
//using api.Domain.DataTypes;
//using Application.Common.Interfaces.Authentication;
//using Application.Common.Interfaces.WorkoutsServices;
//using Application.DTOs;
//using Domain.Common.Entities;
//using Infrastructure.Extensions;
//using Infrastructure.Persistence;
//using Microsoft.EntityFrameworkCore;

//namespace Infrastructure.Services.WorkoutsServices.Workouts
//{
//    public class WorkoutService : IWorkoutService
//    {
//        private readonly DataContext _dataContext;
//        private readonly IAuthService _authService;
//        public WorkoutService(DataContext dataContext, IAuthService authService)
//        {
//            _dataContext = dataContext;
//            _authService = authService;
//        }
//        public async Task<Result<IWorkout, string>> GetWorkoutAsync(Guid userId, Guid id)
//        {
//            var query = _dataContext.Workouts.AsQueryable();

//            query = query.Where(e => e.ID == id);

//            var workout = await query.FirstOrDefaultAsync();

//            if (workout == null)
//            {
//                return new Result<IWorkout, string>.Error("IWorkout ID: {" + id + "} not found");
//            }

//            if (workout.Owner.ID != userId)
//            {
//                return new Result<IWorkout, string>.Error("IWorkout ID: {" + id + "} is not accessible.");
//            }

//            return new Result<IWorkout, string>.Success(workout);
//        }

//        public async Task<List<WorkoutDto>> GetWorkoutListAsync(Guid userId)
//        {
//            var query = _dataContext.Workouts.AsQueryable();

//            query = query.Where(w => w.Owner.ID == userId);

//            query = query.Include(w => w.Exercises);

//            var result = await query.ToListAsync();

//            return result.ToDtos();
//        }


//        public async Task<bool> RemoveExerciseFromWorkoutAsync(Guid userId, Guid workoutId, int exerciseId)
//        {
//            var result = await GetWorkoutAsync(userId, workoutId);

//            var workout = result switch
//            {
//                Result<IWorkout, string>.Success(IWorkout data) => data,
//                _ => null
//            };

//            if (workout == null)
//            {
//                return false;
//            }

//            var exercise = workout.Exercises.SingleOrDefault(e => e.ID == exerciseId);

//            if (exercise == null)
//            {
//                return false;
//            }

//            workout.Exercises.Remove(exercise);
//            await _dataContext.SaveChangesAsync();

//            return true;
//        }

//        public async Task<bool> RemoveWorkoutFromRoutine(Guid userId, Guid routineId, Guid workoutId)
//        {
//            var result = await GetWorkoutRoutineAsync(userId, routineId);

//            var workoutRoutine = result switch
//            {
//                Result<IWorkoutRoutine, string>.Success(IWorkoutRoutine data) => data,
//                _ => null
//            };

//            if (workoutRoutine == null)
//            {
//                return false;
//            }

//            var workout = workoutRoutine.Workouts.SingleOrDefault(w => w.ID == workoutId);

//            if (workout == null)
//            {
//                return false;
//            }

//            workoutRoutine.Workouts.Remove(workout);
//            await _dataContext.SaveChangesAsync();

//            return true;
//        }

//        public async Task<Result<IWorkoutRoutine, string>> GetWorkoutRoutineAsync(Guid userId, Guid id)
//        {
//            var query = _dataContext.WorkoutRoutines.AsQueryable();

//            query = query.Where(e => e.ID == id);

//            var workoutRoutine = await query.FirstOrDefaultAsync();

//            if (workoutRoutine == null)
//            {
//                return new Result<IWorkoutRoutine, string>.Error("IWorkoutRoutine ID: {" + id + "} not found");
//            }

//            if (workoutRoutine.Owner.ID != userId)
//            {
//                return new Result<IWorkoutRoutine, string>.Error("IWorkoutRoutine ID: {" + id + "} is not accessible.");
//            }

//            return new Result<IWorkoutRoutine, string>.Success(workoutRoutine);
//        }

//        public async Task<bool> DeleteWorkoutAsync(Guid userId, Guid workoutId)
//        {
//            var query = _dataContext.Workouts.AsQueryable();

//            query = query.Where(w => w.ID == workoutId);

//            var workout = await query.FirstOrDefaultAsync();

//            if (workout == null)
//            {
//                return false;
//            }

//            if (workout.Owner.ID != userId)
//            {
//                return false;
//            }

//            _dataContext.Workouts.Remove(workout);
//            await _dataContext.SaveChangesAsync();

//            return true;
//        }

//        public async Task<bool> DeleteWorkoutRoutineAsync(Guid userId, Guid workoutRoutineId)
//        {
//            var query = _dataContext.WorkoutRoutines.AsQueryable();

//            query = query.Where(w => w.ID == workoutRoutineId);

//            var workoutRoutine = await query.FirstOrDefaultAsync();

//            if (workoutRoutine == null)
//            {
//                return false;
//            }

//            if (workoutRoutine.Owner.ID != userId)
//            {
//                return false;
//            }

//            _dataContext.WorkoutRoutines.Remove(workoutRoutine);
//            await _dataContext.SaveChangesAsync();

//            return true;
//        }
//    }
//}
