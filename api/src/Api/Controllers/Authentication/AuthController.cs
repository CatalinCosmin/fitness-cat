using Api.Requests;
using Core.Abstractions.Entities;
using Core.Abstractions.Models;
using Core.Abstractions.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Api.Requests.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Core.Abstractions.Services.Verification;
using Microsoft.IdentityModel.Tokens;

namespace Api.Controllers.Authentication
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;
        private readonly IRecaptchaService _recaptchaService;
        public AuthController(ILogger<AuthController> logger, IAuthService authService, IRecaptchaService recaptchaService)
        {
            _logger = logger;
            _authService = authService;
            _recaptchaService = recaptchaService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto registerDto)
        {

            var assessmentResult = _recaptchaService.CreateAssessment(registerDto.Recaptcha, "register");
            if (!assessmentResult.IsNullOrEmpty())
            {
                return BadRequest(assessmentResult);
            }

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
            var assessmentResult = _recaptchaService.CreateAssessment(loginDto.Recaptcha, "login");
            if(!assessmentResult.IsNullOrEmpty())
            {
                return BadRequest(assessmentResult);
            }
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
