using Core.Abstractions.Context;

namespace Core.Services.Workouts
{
    internal class ExerciseService : IExerciseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExerciseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<List<IExercise>?> GetExerciseListAsync(int? muscleGroupId = null, int? muscleId = null, int? equipmentId = null, int? difficulty = null)
        {
            throw new NotImplementedException();
        }
        //public async Task<List<ExerciseDto>> GetExerciseListAsync(int? muscleGroupId = null, int? muscleId = null, int? equipmentId = null, int? difficulty = null)
        //{
        //    var query = _dataContext.Exercises.AsQueryable();

        //    if (muscleGroupId != null)
        //    {
        //        query = query.Where(e => e.MuscleGroups.Any(m => m.ID == muscleGroupId));
        //    }

        //    if (muscleId != null)
        //    {
        //        query = query.Where(e => e.Muscles.Any(m => m.ID == muscleId));
        //    }

        //    if (equipmentId != null)
        //    {
        //        query = query.Where(e => e.Equipments.Any(m => m.ID == equipmentId));
        //    }

        //    if (difficulty != null)
        //    {
        //        query = query.Where(e => e.Difficulty == difficulty);
        //    }

        //    query = query.Include(e => e.Equipments).Include(e => e.MuscleGroups).Include(e => e.Muscles);

        //    var result = await query.ToListAsync();

        //    return result.ToDtos();
        //}

    }
}
