using Api.Response.Extensions;
using Core.Abstractions.Context;
using Core.Abstractions.Services.WorkoutsServices;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers.EntityControllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutsController : Controller
    {
        private readonly ILogger<WorkoutsController> _logger;
        private readonly IWorkoutService _workoutService;
        private readonly IWorkoutRepository _workoutRepository;
        public WorkoutsController(ILogger<WorkoutsController> logger, IWorkoutService workoutService, IWorkoutRepository workoutRepository)
        {
            _logger = logger;
            _workoutService = workoutService;
            _workoutRepository = workoutRepository;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkout([FromRoute] Guid id)
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRepository.GetWorkoutAsync(userId, id);
            if (result == null)
            {
                return NoContent();
            }

            return Ok(result?.ToResponseDto());
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetWorkouts()
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRepository.GetWorkoutListAsync(userId);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }

            return Ok(result?.ToResponseDtos());
        }

        [Authorize]
        [HttpDelete("{workoutId}/exercises/{exerciseId}")]
        public async Task<IActionResult> RemoveExercise([FromRoute] Guid workoutId, [FromRoute] int exerciseId)
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutService.RemoveExerciseFromWorkoutAsync(userId, workoutId, exerciseId);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> CreateWorkout([FromQuery] List<int> exercises)
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRepository.CreateWorkoutAsync(userId, exercises);
            if (result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("PostWorkout", result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout([FromRoute] Guid id)
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRepository.DeleteWorkoutAsync(userId, id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}