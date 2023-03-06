using Core.Abstractions.Entities;
using Core.Abstractions.Models;
using Core.Abstractions.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Authentication
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(IUser registerDto)
        {
            var results = await _authService.RegisterUserAsync(registerDto);

            return results switch
            {
                //Result<bool, List<IValidationFailureResponse>>.Success(bool) => StatusCode(201),
                //Result<bool, List<IValidationFailureResponse>>.Error(List<IValidationFailureResponse> data) => BadRequest(data),
                _ => BadRequest()
            };
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(IUser loginDto)
        {
            var result = await _authService.LoginUserAsync(loginDto);
            return Ok(result);
        }
        [HttpPost("verify_account")]
        public async Task<IActionResult> VerifyAccount(IToken token)
        {
            var result = await _authService.VerifyAccount(token);
            return Ok("Email is verified.");
        }

        //[Authorize]
        //[HttpGet("getUsername")]
        //public async Task<IActionResult> GetUsername(IToken token)
        //{
        //    var result = await _authService.GetUsername(token);
        //    return result switch
        //    {
        //        Result<string, string>.Error(string data) => BadRequest(data),
        //        Result<string, string>.Success(string data) => Ok(data),
        //        _ => BadRequest()
        //    };
        //}
    }
}
