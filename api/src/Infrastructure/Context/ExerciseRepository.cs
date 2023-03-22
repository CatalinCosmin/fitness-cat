using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Core.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    class ExerciseRepository : IExerciseRepository
    {
        private readonly DataContext _context;

        public ExerciseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IExercise?> GetExerciseAsync(int id)
        {
            var result = await _context.Exercises
                .Where(e => e.ID == id)
                .Include(e => e.Equipments)
                .Include(e => e.MuscleGroups)
                .Include(e => e.Muscles)
                .SingleOrDefaultAsync();
            return result?.ToModel();
        }
        public IExercise? GetExercise(int id)
        {
            var result = _context.Exercises
                .Where(e => e.ID == id)
                .Include(e => e.Equipments)
                .Include(e => e.MuscleGroups)
                .Include(e => e.Muscles)
                .SingleOrDefault();
            return result?.ToModel();
        }

        public async Task<List<IExercise>?> GetExerciseListAsync(int? muscleGroupId = null, int? muscleId = null, int? equipmentId = null, int? difficulty = null)
        {
            
            var query = _context.Exercises.AsQueryable();
            query = query.Include(e => e.Equipments).Include(e => e.MuscleGroups).Include(e => e.Muscles);

            if (muscleGroupId != null)
            {
                query = query.Where(e => e.MuscleGroups.Any(m => m.ID == muscleGroupId));
            }

            if (muscleId != null)
            {
                query = query.Where(e => e.Muscles.Any(m => m.ID == muscleId));
            }

            if (equipmentId != null)
            {
                query = query.Where(e => e.Equipments.Any(m => m.ID == equipmentId));
            }

            if (difficulty != null)
            {
                query = query.Where(e => e.Difficulty == difficulty);
            }

            var result = await query.ToListAsync();

            return result.ToModels();
        }
    }
}
