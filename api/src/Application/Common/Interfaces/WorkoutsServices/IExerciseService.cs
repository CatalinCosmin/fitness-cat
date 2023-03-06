using Application.DTOs;

namespace Application.Common.Interfaces.WorkoutsServices
{
    public interface IExerciseService
    {
        Task<ExerciseDto?> GetExerciseAsync(int id);
        Task<List<ExerciseDto>> GetExerciseListAsync(int? muscleGroupId = null, int? muscleId = null, int? equipmentId = null, int? difficulty = null);
    }
}