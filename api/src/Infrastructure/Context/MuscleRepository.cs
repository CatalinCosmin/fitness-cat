using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    internal class MuscleRepository : IMuscleRepository
    {
        private readonly DataContext _context;
        public MuscleRepository(DataContext context)
        {
            _context = context;
        }
        public IMuscle? GetMuscle(int id)
        {
            return _context.Muscles
                .Where(m => m.ID == id)
                .FirstOrDefault()?.ToModel();
        }

        public async Task<IMuscle?> GetMuscleAsync(int id)
        {
            var result = await _context.Muscles
                .Where(m => m.ID == id)
                .SingleOrDefaultAsync();

            return result?.ToModel();
        }

        public List<IMuscle>? GetMuscleList(int id)
        {
            return _context.Muscles
                .Where(m => m.MuscleGroups.Any(mg => mg.ID == id))
                .ToList()?
                .ToModels();
                
        }

        public async Task<List<IMuscle>?> GetMuscleListAsync(int id)
        {
            var result = await _context.Muscles
                .Where(m => m.MuscleGroups.Any(mg => mg.ID == id))
                .ToListAsync();

            return result?.ToModels();

        }
    }
}
