using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Core.Abstractions.Services.Auth;
using Core.Abstractions.Services.WorkoutsServices;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers.EntityControllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusclesController : Controller
    {
        private readonly ILogger<MusclesController> _logger;
        private readonly IMuscleService _muscleService;
        private readonly IMuscleRepository _muscleRepository;
        public MusclesController(ILogger<MusclesController> logger, IMuscleService muscleService, IMuscleRepository muscleRepository)
        {
            _logger = logger;
            _muscleService = muscleService;
            _muscleRepository = muscleRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetMuscles([FromQuery] int muscleGroupId)
        {
            var muscles = await _muscleRepository.GetMuscleListAsync(muscleGroupId);
            if (muscles == null)
            {
                return BadRequest();
            }
            return Ok(muscles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMuscle([FromRoute] int id)
        {
            var result = await _muscleRepository.GetMuscleAsync(id);

            return result switch
            {
                IMuscle => Ok(result),
                _ => NoContent()
            };
        }
    }
}
