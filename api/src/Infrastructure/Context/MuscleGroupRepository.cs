using Application.DTOs;
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

        public List<IMuscleGroup>? GetMuscleGroupList()
        {
            return _context.MuscleGroups
                .Include(mg => mg.Muscles)
                .ToList()
                .ToModels();
        }
    }
}
