//using api.Controllers.Authentication;
//using api.Domain.Abstractions.Services.Auth;
//using api.Domain.Abstractions.Services.WorkoutBuilder;
//using api.Domain.Abstractions.Services.WorkoutsServices;
//using Application.Common.Interfaces.Authentication;
//using Application.Common.Interfaces.WorkoutBuilder;
//using Application.Common.Interfaces.WorkoutsServices;
//using Infrastructure.Extensions;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace api.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class WorkoutBuilderController : Controller
//    {
//        private readonly ILogger<AuthController> _logger;
//        private readonly IAuthService _authService;
//        private readonly IWorkoutBuilderService _workoutBuilderService;
//        private readonly IWorkoutService _workoutService;
//        public WorkoutBuilderController(ILogger<AuthController> logger, IAuthService authService, IWorkoutBuilderService workoutBuilderService, IWorkoutService workoutService)
//        {
//            _logger = logger;
//            _authService = authService;
//            _workoutBuilderService = workoutBuilderService;
//            _workoutService = workoutService;
//        }

//        [Authorize]
//        [HttpPost("/workout")]
//        public async Task<IActionResult> PostWorkout([FromQuery] List<int> exercises)
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutBuilderService.CreateWorkoutAsync(userId, exercises);
//            if (result == null)
//            {
//                return BadRequest();
//            }
//            return CreatedAtAction("PostWorkout", result);
//        }

//        [Authorize]
//        [HttpPost("/workoutroutine")]
//        public async Task<IActionResult> PostWorkoutRoutine([FromQuery] List<Guid> workouts)
//        {
//            var userId = HttpContext.GetAccountId();

//            var result = await _workoutBuilderService.CreateWorkoutRoutineAsync(userId, workouts);
//            if (result == null)
//            {
//                return BadRequest();
//            }
//            return CreatedAtAction("PostWorkoutRoutine", result);
//        }
//    }
//}
