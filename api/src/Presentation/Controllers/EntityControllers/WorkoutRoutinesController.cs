//using api.Domain.Abstractions.Services.Auth;
//using api.Domain.Abstractions.Services.WorkoutsServices;
//using api.Domain.DataTypes;
//using Application.Common.Interfaces.Authentication;
//using Application.Common.Interfaces.WorkoutsServices;
//using Application.DTOs;
//using Infrastructure.Extensions;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;

//namespace api.Controllers.EntityControllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WorkoutRoutinesController : Controller
//    {
//        private readonly ILogger<WorkoutRoutinesController> _logger;
//        private readonly IAuthService _authService;
//        private readonly IWorkoutRoutineService _workoutRoutineService;
//        public WorkoutRoutinesController(ILogger<WorkoutRoutinesController> logger, IAuthService authService, IWorkoutRoutineService workoutRoutineService)
//        {
//            _logger = logger;
//            _authService = authService;
//            _workoutRoutineService = workoutRoutineService;
//        }

//        [Authorize]
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetWorkoutRoutine([FromRoute] Guid id)
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutRoutineService.GetWorkoutRoutineDtoAsync(userId, id);
//            return result switch
//            {
//                Result<WorkoutRoutineDto, string>.Success(WorkoutRoutineDto data) => Ok(data),
//                Result<WorkoutRoutineDto, string>.Error(string data) => BadRequest(data),
//                _ => BadRequest()
//            };
//        }

//        [Authorize]
//        [HttpGet("")]
//        public async Task<IActionResult> GetWorkoutRoutines()
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutRoutineService.GetWorkoutRoutineListAsync(userId);
//            if (result.IsNullOrEmpty())
//            {
//                return NoContent();
//            }

//            return Ok(result);
//        }

//        [Authorize]
//        [HttpPut("{workoutRoutineId}/workout/{workoutId}")]
//        public async Task<IActionResult> RemoveExercise([FromRoute] Guid workoutRoutineId, [FromRoute] Guid workoutId)
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutRoutineService.RemoveWorkoutFromRoutine(userId, workoutRoutineId, workoutId);

//            if (result == false)
//            {
//                return BadRequest();
//            }

//            return Ok();
//        }

//        [Authorize]
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteWorkout([FromRoute] Guid id)
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutRoutineService.DeleteWorkoutRoutineAsync(userId, id);

//            if (result == false)
//            {
//                return BadRequest();
//            }

//            return Ok();
//        }

//    }
//}
