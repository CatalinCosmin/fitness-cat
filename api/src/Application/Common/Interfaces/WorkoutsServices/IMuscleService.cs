using Domain.Common.Entities;
using Application.DTOs;

namespace Application.Common.Interfaces.WorkoutsServices
{
    public interface IMuscleService
    {
        Task<IMuscle?> GetMuscleAsync(int id);
        Task<List<MuscleDto>> GetMuscleListAsync(int id);
    }
}