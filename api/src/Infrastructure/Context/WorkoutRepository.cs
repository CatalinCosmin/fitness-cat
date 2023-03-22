using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Core.DataTypes;
using Infrastructure.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    internal class WorkoutRepository : IWorkoutRepository
    {
        private readonly DataContext _context;
        public WorkoutRepository(DataContext context)
        {
            _context = context;
        }

        public IWorkout? GetWorkout(Guid userId, Guid id)
        {
            return _context.Workouts
                .Include(w => w.Exercises)
                .Where(w => w.ID == id && w.Owner.ID == userId)
                .FirstOrDefault()?
                .ToModel();

        }

        public async Task<IWorkout?> GetWorkoutAsync(Guid userId, Guid id)
        {
            var result = await _context.Workouts
                .Include(w => w.Exercises)
                .Where(w => w.ID == id && w.Owner.ID == userId)
                .SingleOrDefaultAsync();
            return result?.ToModel();
        }

        public List<IWorkout>? GetWorkoutList(Guid userId)
        {
            return _context.Workouts
                .Include(w => w.Exercises)
                .Where(w => w.Owner.ID == userId)
                .ToList()
                .ToModels();
        }

        public async Task<List<IWorkout>?> GetWorkoutListAsync(Guid userId)
        {
            var result = await _context.Workouts
                .Include(w => w.Exercises)
                .Where(w => w.Owner.ID == userId)
                .ToListAsync();
            return result?.ToModels();
        }

        public async Task<bool> DeleteWorkoutAsync(Guid userId, Guid workoutId)
        {
            var workout = await _context.Workouts
                .Where(w => w.ID == workoutId && w.Owner.ID == userId)
                .FirstOrDefaultAsync();

            if(workout is null)
            {
                return false;
            }

            _context.Workouts.Remove(workout);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Guid?> CreateWorkoutAsync(Guid userId, List<int> exercisesIDs)
        {

            var exercises = new List<Exercise>();
            foreach (var id in exercisesIDs)
            {
                var exercise = await _context.Exercises.Where(e => e.ID == id).SingleOrDefaultAsync();

                if (exercise is null)
                {
                    return null;
                }

                exercises.Add(exercise);
            }

            var user = await _context.Users.SingleAsync(u => u.ID == userId);

            if(user is null)
            {
                return null;
            }

            var workout = new Workout
            {
                ID = Guid.NewGuid(),
                AccesibilityLevel = 0,
                Exercises = exercises,
                CreationDate = DateOnly.FromDateTime(DateTime.UtcNow),
                Owner = user
            };

            _context.Workouts.Add(workout);
            await _context.SaveChangesAsync();

            return workout.ID;
        }
    }
}
