using Api.Response.Extensions;
using Core.Abstractions.Context;
using Core.Abstractions.Entities;
using Core.Abstractions.Services.WorkoutsServices;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers.EntityControllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutRoutinesController : Controller
    {
        private readonly ILogger<WorkoutRoutinesController> _logger;
        private readonly IWorkoutRoutineService _workoutRoutineService;
        private readonly IWorkoutRoutineRepository _workoutRoutineRepository;
        public WorkoutRoutinesController(ILogger<WorkoutRoutinesController> logger, IWorkoutRoutineService workoutRoutineService, IWorkoutRoutineRepository workoutRoutineRepository)
        {
            _logger = logger;
            _workoutRoutineService = workoutRoutineService;
            _workoutRoutineRepository = workoutRoutineRepository;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkoutRoutine([FromRoute] Guid id)
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRoutineRepository.GetWorkoutRoutineAsync(userId, id);
            return result switch
            {
                IWorkoutRoutine => Ok(result?.ToResponseDto()),
                _ => BadRequest()
            };
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetWorkoutRoutines()
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRoutineRepository.GetWorkoutRoutineListAsync(userId);
            if (result.IsNullOrEmpty())
            {
                return NoContent();
            }

            return Ok(result?.ToResponseDtos());
        }

        [Authorize]
        [HttpDelete("{workoutRoutineId}/workout/{workoutId}")]
        public async Task<IActionResult> RemoveExercise([FromRoute] Guid workoutRoutineId, [FromRoute] Guid workoutId)
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRoutineService.RemoveWorkoutFromRoutine(userId, workoutRoutineId, workoutId);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }

        [Authorize]
        [HttpPost("/workoutroutine")]
        public async Task<IActionResult> PostWorkoutRoutine([FromQuery] List<Guid> workouts)
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRoutineRepository.CreateWorkoutRoutineAsync(userId, workouts);
            if (result == null)
            {
                return BadRequest();
            }
            return CreatedAtAction("PostWorkoutRoutine", result);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkout([FromRoute] Guid id)
        {
            var userId = HttpContext.GetAccountId();

            var result = await _workoutRoutineRepository.DeleteWorkoutRoutineAsync(userId, id);

            if (result == false)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
