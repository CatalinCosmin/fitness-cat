using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using Mailosaur.Models;
using Mailosaur;
using Microsoft.Extensions.Configuration;
using Core.Entities;
using Core.Abstractions.Services.Auth;
using Core.Abstractions.Context;
using Core.Abstractions.Models;
using System.Security.Authentication;
using FluentValidation;
using Core.Services.Validators;

namespace Core.Services.Authentication
{
    internal class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly RegisterValidator _registerValidator;
        private readonly LoginValidator _loginValidator;
        private readonly IConfiguration _configuration;
        public AuthService(IUserRepository userRepository, IUnitOfWork unitOfWork, RegisterValidator registerValidator, LoginValidator loginValidator, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
            _configuration = configuration;
        }

        public async Task<string?> LoginUserAsync(IUser loginDto)
        {
            var results = _loginValidator.Validate(loginDto);
            if (results.IsValid == false)
            {
                throw new ValidationException(results.Errors.First().ErrorMessage);
            }
            var user = await _userRepository.GetUser(username: loginDto.Username);
            if (user is null)
            {
                user = await _userRepository.GetUser(email: loginDto.Email);
            }

            if (user == null)
            {
                throw new AuthenticationException();
            }
            if (BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password) == false)
            {
                throw new AuthenticationException();
            }
            if (user.isVerified == false)
            {
                // return "ERROR: Email is not verified.";
            }
            user.LastAuthenticationDate = DateTime.UtcNow;
            await _unitOfWork.SaveAsync();

            var jwtToken = CreateJwtToken(user.ID);
            return jwtToken;
        }

        public string CreateJwtToken(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.ID.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, user.Username),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddDays(1)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }

        public async Task<bool> RegisterUserAsync(IUser registerDto)
        {
            var result = await _registerValidator.ValidateAsync(registerDto);
            if (result.IsValid == false)
            {
                return false;
            }
            registerDto.Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            var success = await _userRepository.AddUser(registerDto);

            if(success == false) 
            {
                return false;
            }
            //SendValidationEmail(registerDto.ID);

            return true;
        }

        public void SendValidationEmail(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if(user is null)
            {
                throw new ArgumentException();
            }

            var jwtToken = GenerateVerificationJwt(user.ID);

            var clientUrl = _configuration["Client:Url"];
            var webAdress = clientUrl + "/verify_account?token=" + jwtToken;

            var issuer = _configuration["Email:Address"];
            var issuerPassword = _configuration["Email:Password"];

            var apiKey = _configuration["Mailosaur:Api:Key"];
            var serverId = _configuration["Mailosaur:Id"];

            var mailosaur = new MailosaurClient(apiKey);

            mailosaur.Messages.Create(serverId, new MessageCreateOptions()
            {
                To = user.Email,
                Subject = "Email verification - FitnessCat",
                Send = true,
                Html = @"<h1>FitnessCat: New Account Verification</h1>" +
                @"<a href=" + webAdress + ">Please click here to verify your new FitnessCat account</a>"
            });
            //Debug.WriteLine(webAdress);
        }

        public string GenerateVerificationJwt(Guid id)
        {
            var user = _userRepository.GetUserById(id);
            if(user is null)
            {
                throw new ArgumentException();
            }

            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Email", user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Expires = DateTime.UtcNow.AddDays(2)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);

            return jwtToken;
        }

        public async Task<Guid> VerifyAccount(IToken token)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]!);
            var issuer = _configuration["JWT:Issuer"];
            var audience = _configuration["JWT:Audience"];

            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = audience,
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
            var claims = handler.ValidateToken(token.Token, validations, out var tokenSecure);
            var claim = claims.Claims.FirstOrDefault(o => o.Type == JwtRegisteredClaimNames.Email);
            if (claim == null)
            {
                throw new InvalidOperationException();
            }

            var email = claim.Value;
            var user = await _userRepository.GetUser(email: email);
            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }
            if (user.isVerified == false)
            {
                //
            }

            user.isVerified = true;
            await _unitOfWork.SaveAsync();

            return user.ID;
        }
    }
}
