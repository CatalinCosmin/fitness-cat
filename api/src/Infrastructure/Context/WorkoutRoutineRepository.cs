using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Core.DataTypes;
using Infrastructure.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    internal class WorkoutRoutineRepository : IWorkoutRoutineRepository
    {
        private readonly DataContext _context;
        public WorkoutRoutineRepository(DataContext context)
        {
            _context = context;
        }

        public IWorkoutRoutine? GetWorkoutRoutine(Guid userId, Guid id)
        {
            return _context.WorkoutRoutines
                .Where(wr => wr.ID == id)
                .Where(wr => wr.Owner.ID == userId)
                .Include(wr => wr.Workouts)
                .ThenInclude(w => w.Exercises)
                .IgnoreAutoIncludes()
                .FirstOrDefault()?
                .ToModel();
        }

        public async Task<IWorkoutRoutine?> GetWorkoutRoutineAsync(Guid userId, Guid id)
        {
            var result = await _context.WorkoutRoutines
                .Where(wr => wr.ID == id)
                .Where(wr => wr.Owner.ID == userId)
                .Include(wr => wr.Workouts)
                .ThenInclude(w => w.Exercises)
                .IgnoreAutoIncludes()
                .FirstOrDefaultAsync();
            return result?.ToModel();
        }

        public List<IWorkoutRoutine>? GetWorkoutRoutineList(Guid userId)
        {
            return _context.WorkoutRoutines
                .Where(wr => wr.Owner.ID == userId)
                .Include(wr => wr.Workouts)
                .ThenInclude(w => w.Exercises)
                .IgnoreAutoIncludes()
                .ToList()?
                .ToModels();
        }

        public async Task<List<IWorkoutRoutine>?> GetWorkoutRoutineListAsync(Guid userId)
        {
            var result = await _context.WorkoutRoutines
                .Where(wr => wr.Owner.ID == userId)
                .Include(wr => wr.Workouts)
                .ThenInclude(w => w.Exercises)
                .IgnoreAutoIncludes()
                .ToListAsync();
            return result.ToModels();
        }

        public async Task<bool> DeleteWorkoutRoutineAsync(Guid userId, Guid workoutRoutineId)
        {
            var workoutRoutine = await _context.WorkoutRoutines
                .Where(wr => wr.ID == workoutRoutineId)
                .Where(wr => wr.Owner.ID == userId)
                .FirstOrDefaultAsync();

            if(workoutRoutine is null)
            {
                return false;
            }

            _context.WorkoutRoutines.Remove(workoutRoutine);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Guid?> CreateWorkoutRoutineAsync(Guid userId, List<Guid> workoutIDs)
        {
            var workouts = new List<Workout>();

            foreach (var id in workoutIDs)
            {
                var workout = await _context.Workouts.Where(w => w.Owner.ID == userId && w.ID == id).SingleOrDefaultAsync();

                if (workout is null)
                {
                    return null;
                }

                workouts.Add(workout);
            }

            var user = await _context.Users.SingleAsync(u => u.ID == userId);

            var workoutRoutine = new WorkoutRoutine
            {
                ID = Guid.NewGuid(),
                AccesibilityLevel = 0,
                Workouts = workouts,
                Owner = user
            };

            _context.WorkoutRoutines.Add(workoutRoutine);
            await _context.SaveChangesAsync();

            return workoutRoutine.ID;
        }
    }
}
