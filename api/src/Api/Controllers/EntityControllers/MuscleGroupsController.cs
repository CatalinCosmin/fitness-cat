using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.EntityControllers
{
    [ApiController]
    [Route("[controller]")]
    public class MuscleGroupsController : Controller
    {
        private readonly ILogger<MuscleGroupsController> _logger;
        private readonly IMuscleGroupRepository _muscleGroupRepository;
        public MuscleGroupsController(ILogger<MuscleGroupsController> logger, IMuscleGroupRepository muscleGroupRepository)
        {
            _logger = logger;
            _muscleGroupRepository = muscleGroupRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetMuscleGroups()
        {
            var muscleGroups = await _muscleGroupRepository.GetMuscleGroupListAsync();
            if (muscleGroups == null)
            {
                return BadRequest();
            }
            return Ok(muscleGroups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMuscleGroup([FromRoute] int id)
        {
            var result = await _muscleGroupRepository.GetMuscleGroupAsync(id);

            return result switch
            {
                IMuscleGroup => Ok(result),
                _ => NoContent()
            };
        }
    }
}
