//using Domain.Common.Entities;
//using Application.DTOs;
//using api.Domain.DataTypes;

//namespace Application.Common.Interfaces.Authentication
//{
//    public interface IAuthService
//    {
//        Task<Result<bool, List<IValidationFailureResponse>>> RegisterUserAsync(RegisterDto registerDto);
//        Task<Result<string, List<IValidationFailureResponse>>> LoginUserAsync(LoginDto loginDto);
//        Task<bool> VerifyAccount(VerifyTokenDto token);
//        Task<Result<User, string>> GetUserAsync(VerifyTokenDto token);
//        Task<Result<string, string>> GetUsername(VerifyTokenDto token);
//    }
//}
