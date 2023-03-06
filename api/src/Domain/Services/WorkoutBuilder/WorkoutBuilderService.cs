//using api.Domain.Abstractions.Services.Auth;
//using api.Domain.Abstractions.Services.WorkoutBuilder;
//using api.Domain.Abstractions.Services.WorkoutsServices;
//using api.Domain.DataTypes;
//using Application.Common.Interfaces.Authentication;
//using Application.Common.Interfaces.WorkoutBuilder;
//using Application.Common.Interfaces.WorkoutsServices;
//using Domain.Common.Entities;
//using Infrastructure.Persistence;
//using Microsoft.EntityFrameworkCore;

//namespace Infrastructure.Services.WorkoutBuilder
//{
//    public class WorkoutBuilderService : IWorkoutBuilderService
//    {
//        private readonly DataContext _dataContext;
//        private readonly IAuthService _authService;
//        private readonly IWorkoutService _workoutService;
//        private readonly IExerciseService _exerciseService;
//        public WorkoutBuilderService(DataContext dataContext, IAuthService authService, IWorkoutService workoutService, IExerciseService exerciseService)
//        {
//            _dataContext = dataContext;
//            _authService = authService;
//            _workoutService = workoutService;
//            _exerciseService = exerciseService;
//        }

//        public async Task<Result<Guid, string>> CreateWorkoutAsync(Guid userId, List<int> exercisesIDs)
//        {

//            var exercises = new List<Exercise>();
//            foreach (var id in exercisesIDs)
//            {
//                var result = await _exerciseService.GetExerciseAsync(id);

//                if (result == null)
//                {
//                    return new Result<Guid, string>.Error("Exercise ID: {" + id + "} not found");
//                }

//                var exercise = await _dataContext.Exercises.FirstAsync(e => e.ID == result.ID);

//                exercises.Add(exercise);
//            }

//            var user = await _dataContext.Users.SingleAsync(u => u.ID == userId);

//            var workout = new IWorkout
//            {
//                ID = Guid.NewGuid(),
//                AccesibilityLevel = 0,
//                Exercises = exercises,
//                CreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
//                Owner = user
//            };

//            _dataContext.Workouts.Add(workout);
//            await _dataContext.SaveChangesAsync();

//            return new Result<Guid, string>.Success(workout.ID);
//        }

//        public async Task<Result<Guid, string>> CreateWorkoutRoutineAsync(Guid userId, List<Guid> workoutIDs)
//        {
//            var workouts = new List<IWorkout>();

//            foreach (var id in workoutIDs)
//            {
//                var result = await _workoutService.GetWorkoutAsync(userId, id);

//                var workout = result switch
//                {
//                    Result<IWorkout, string>.Error(string data) => null,
//                    Result<IWorkout, string>.Success(IWorkout data) => data,
//                    _ => null
//                };

//                if (workout == null)
//                {
//                    return result switch
//                    {
//                        Result<IWorkout, string>.Error(string data) => new Result<Guid, string>.Error(data),
//                        _ => new Result<Guid, string>.Error("Error while getting workout.")
//                    };
//                }

//                workouts.Add(workout);
//            }

//            var user = await _dataContext.Users.SingleAsync(u => u.ID == userId);

//            var workoutRoutine = new IWorkoutRoutine
//            {
//                ID = Guid.NewGuid(),
//                AccesibilityLevel = 0,
//                Workouts = workouts,
//                Owner = user
//            };

//            _dataContext.WorkoutRoutines.Add(workoutRoutine);
//            await _dataContext.SaveChangesAsync();

//            return new Result<Guid, string>.Success(workoutRoutine.ID);
//        }
//    }
//}
