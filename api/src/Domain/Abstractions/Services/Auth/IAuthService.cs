using Core.Abstractions.Models;

namespace Core.Abstractions.Services.Auth
{
    public interface IAuthService
    {

        Task<Guid> LoginUserAsync(IUser loginDto);

        string CreateJwtToken(Guid id);

        Task<List<IValidationFailureResponse>?> RegisterUserAsync(IUser registerDto);

        void SendValidationEmail(Guid id);
        string GenerateVerificationJwt(Guid id);
        Task<Guid> VerifyAccount(IToken token);
    }
}
