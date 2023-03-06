using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Core.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    class ExerciseRepository : IExerciseRepository
    {
        private readonly DataContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ExerciseRepository(DataContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IExercise? GetExercise(int id)
        {
            return _context.Exercises
                .Where(e => e.ID == id)
                .Include(e => e.Equipments)
                .Include(e => e.MuscleGroups)
                .Include(e => e.Muscles)
                .FirstOrDefault()?.ToModel();
        }

        public IExercise? GetExercise(Func<IExercise, bool> predicate)
        {
            return _context.Exercises
                .Where((Func<Entities.Exercise, bool>)predicate)
                .FirstOrDefault()?.ToModel();
        }

        public async Task<List<IExercise>?> GetExerciseListAsync(int? muscleGroupId = null, int? muscleId = null, int? equipmentId = null, int? difficulty = null)
        {
            
            var query = _context.Exercises.AsQueryable();

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

            query = query.Include(e => e.Equipments).Include(e => e.MuscleGroups).Include(e => e.Muscles);

            var result = await query.ToListAsync();

            return result.ToModels();
        }
    }
}
