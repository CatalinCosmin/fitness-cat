using Domain.Common.Entities;
using Application.DTOs;

namespace Application.Common.Interfaces.WorkoutsServices
{
    public interface IMuscleGroupService
    {
        Task<IMuscleGroup?> GetMuscleGroupAsync(int id);
        Task<List<MuscleGroupDto>> GetMuscleGroupListAsync();
    }
}