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

//namespace Infrastructure.Services.WorkoutsServices.WorkoutRoutines
//{
//    public class WorkoutRoutineService : IWorkoutRoutineService
//    {
//        private readonly DataContext _dataContext;
//        private readonly IAuthService _authService;
//        public WorkoutRoutineService(DataContext dataContext, IAuthService authService)
//        {
//            _dataContext = dataContext;
//            _authService = authService;
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
//            _dataContext.SaveChanges();

//            return true;
//        }

//        public async Task<Result<IWorkoutRoutine, string>> GetWorkoutRoutineAsync(Guid userId, Guid id)
//        {
//            var query = _dataContext.WorkoutRoutines.AsQueryable();

//            query = query.Where(wr => wr.ID == id);
//            query = query.Where(wr => wr.Owner.ID == userId);
//            query = query.Include(wr => wr.Workouts).ThenInclude(w => w.Exercises).IgnoreAutoIncludes();

//            var workoutRoutine = await query.FirstOrDefaultAsync();

//            if (workoutRoutine == null)
//            {
//                return new Result<IWorkoutRoutine, string>.Error("IWorkoutRoutine ID: {" + id + "} not found or accessible.");
//            }

//            return new Result<IWorkoutRoutine, string>.Success(workoutRoutine);
//        }

//        public async Task<Result<WorkoutRoutineDto, string>> GetWorkoutRoutineDtoAsync(Guid userId, Guid id)
//        {
//            var query = _dataContext.WorkoutRoutines.AsQueryable();

//            query = query.Where(wr => wr.ID == id);
//            query = query.Where(wr => wr.Owner.ID == userId);
//            query = query.Include(wr => wr.Workouts).ThenInclude(w => w.Exercises).IgnoreAutoIncludes();

//            var workoutRoutine = await query.FirstOrDefaultAsync();

//            if (workoutRoutine == null)
//            {
//                return new Result<WorkoutRoutineDto, string>.Error("IWorkoutRoutine ID: {" + id + "} not found or accessible.");
//            }

//            return new Result<WorkoutRoutineDto, string>.Success(workoutRoutine.ToDto());
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

//        public async Task<List<WorkoutRoutineDto>> GetWorkoutRoutineListAsync(Guid userId)
//        {
//            var query = _dataContext.WorkoutRoutines.AsQueryable();

//            query = query.Where(wr => wr.Owner.ID == userId);

//            query = query.Include(wr => wr.Workouts).ThenInclude(w => w.Exercises);

//            var result = await query.ToListAsync();

//            return result.ToDtos();
//        }
//    }
//}
