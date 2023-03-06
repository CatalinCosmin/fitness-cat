using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Infrastructure.Extensions;
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

        public List<IMuscle>? GetMuscleList(Func<IMuscle, bool> predicate)
        {
            return _context.Muscles
                .Where((Func<Entities.Muscle, bool>)predicate)?
                .ToList()?
                .ToModels();
        }

        public List<IMuscle>? GetMuscleList(int id)
        {
            return _context.Muscles
                .Where(m => m.MuscleGroups.Any(mg => mg.ID == id))
                .ToList()?
                .ToModels();
                
        }
    }
}
