//using api.Domain.Abstractions.Services.Auth;
//using api.Domain.Abstractions.Services.WorkoutsServices;
//using api.Domain.DataTypes;
//using Application.Common.Interfaces.Authentication;
//using Application.Common.Interfaces.WorkoutsServices;
//using Domain.Common.Entities;
//using Infrastructure.Extensions;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;

//namespace api.Controllers.EntityControllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WorkoutsController : Controller
//    {
//        private readonly ILogger<WorkoutsController> _logger;
//        private readonly IAuthService _authService;
//        private readonly IWorkoutService _workoutService;
//        public WorkoutsController(ILogger<WorkoutsController> logger, IAuthService authService, IWorkoutService workoutService)
//        {
//            _logger = logger;
//            _authService = authService;
//            _workoutService = workoutService;
//        }

//        [Authorize]
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetWorkout([FromRoute] Guid id)
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutService.GetWorkoutAsync(userId, id);
//            return result switch
//            {
//                Result<IWorkout, string>.Success(IWorkout data) => Ok(data),
//                Result<IWorkout, string>.Error(string data) => BadRequest(data),
//                _ => BadRequest()
//            };
//        }

//        [Authorize]
//        [HttpGet("")]
//        public async Task<IActionResult> GetWorkouts()
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutService.GetWorkoutListAsync(userId);
//            if (result.IsNullOrEmpty())
//            {
//                return NoContent();
//            }

//            return Ok(result);
//        }

//        [Authorize]
//        [HttpPut("{workoutId}/exercise/{exerciseId}")]
//        public async Task<IActionResult> RemoveExercise([FromRoute] Guid workoutId, [FromRoute] int exerciseId)
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutService.RemoveExerciseFromWorkoutAsync(userId, workoutId, exerciseId);

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

//            var result = await _workoutService.DeleteWorkoutAsync(userId, id);

//            if (result == false)
//            {
//                return BadRequest();
//            }

//            return Ok();
//        }

//    }
//}
