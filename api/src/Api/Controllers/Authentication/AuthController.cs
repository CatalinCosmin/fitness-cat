using Api.Requests;
using Core.Abstractions.Entities;
using Core.Abstractions.Models;
using Core.Abstractions.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Api.Requests.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public async Task<IActionResult> Register(RegisterRequestDto registerDto)
        {
            var results = await _authService.RegisterUserAsync(registerDto.ToModel());

            if(results == false)
            {
                return BadRequest(registerDto);
            }
            return Created("register", registerDto.Email);

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto loginDto)
        {
            var result = await _authService.LoginUserAsync(loginDto.ToModel());
            return Ok(result);
        }
        [HttpPost("verify_account")]
        public async Task<IActionResult> VerifyAccount(IToken token)
        {
            var result = await _authService.VerifyAccount(token);
            return Ok("Email is verified.");
        }
    }
}
