namespace Core.Abstractions.Services.Verification
{
    public interface IRecaptchaService
    {
        public List<string> CreateAssessment(string token, string action);
    }
}
