using Core.Abstractions.Models;

namespace Core.Abstractions.Services.Auth
{
    public interface IAuthService
    {

        Task<string?> LoginUserAsync(IUser loginDto);
        string CreateJwtToken(Guid id);
        void SendValidationEmail(Guid id);
        string GenerateVerificationJwt(Guid id);
        Task<Guid> VerifyAccount(IToken token);
        Task<bool> RegisterUserAsync(IUser registerDto);
    }
}
