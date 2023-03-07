using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    internal class MuscleGroupRepository : IMuscleGroupRepository
    {
        private readonly DataContext _context;
        public MuscleGroupRepository(DataContext context)
        {
            _context = context;
        }

        public IMuscleGroup? GetMuscleGroup(int id)
        {
            return _context.MuscleGroups
                .Where(mg => mg.ID == id)
                .Include(mg => mg.Muscles)
                .FirstOrDefault()?
                .ToModel();
        }

        public async Task<IMuscleGroup?> GetMuscleGroupAsync(int id)
        {
            var result = await _context.MuscleGroups
                .Where(mg => mg.ID == id)
                .Include(mg => mg.Muscles)
                .FirstOrDefaultAsync();
            return result?.ToModel();

        }

        public List<IMuscleGroup>? GetMuscleGroupList()
        {
            return _context.MuscleGroups
                .Include(mg => mg.Muscles)
                .ToList()
                .ToModels();
        }

        public async Task<List<IMuscleGroup>?> GetMuscleGroupListAsync()
        {
            var result = await _context.MuscleGroups
                .Include(mg => mg.Muscles)
                .ToListAsync();

            return result?.ToModels();
        }
    }
}
