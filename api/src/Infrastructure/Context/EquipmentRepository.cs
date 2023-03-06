using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Infrastructure.Extensions;

namespace Infrastructure.Context
{
    internal class EquipmentRepository : IEquipmentRepository
    {
        private readonly DataContext _context;
        public EquipmentRepository(DataContext context)
        {
            _context = context;
        }
        public IEquipment? GetEquipment(int id)
        {
            return _context.Equipments
                .Where(e => e.ID == id)
                .FirstOrDefault()?
                .ToModel();
        }
    }
}
