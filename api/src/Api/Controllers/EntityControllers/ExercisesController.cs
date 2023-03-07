using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Core.Abstractions.Services.WorkoutsServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers.EntityControllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : Controller
    {
        private readonly ILogger<ExercisesController> _logger;
        private readonly IExerciseService _exerciseService;
        private readonly IExerciseRepository _exerciseRepository;

        public ExercisesController(ILogger<ExercisesController> logger, IExerciseService exerciseService, IExerciseRepository exerciseRepository)
        {
            _logger = logger;
            _exerciseService = exerciseService;
            _exerciseRepository = exerciseRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetExercises([FromQuery] int? muscleGroupId = null, [FromQuery] int? muscleId = null, [FromQuery] int? equipmentId = null, [FromQuery] int? difficulty = null)
        {
            var exercises = await _exerciseRepository.GetExerciseListAsync(muscleGroupId, muscleId, equipmentId, difficulty);
            if (exercises.IsNullOrEmpty())
            {
                return NotFound();
            }
            return Ok(exercises);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercise([FromRoute] int id)
        {
            var result = await _exerciseRepository.GetExerciseAsync(id);

            return result switch
            {
                IExercise => Ok(result),
                _ => NotFound()
            };
        }
    }
}
