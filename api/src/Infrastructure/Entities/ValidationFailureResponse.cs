using Core.Abstractions.Entities;

namespace Infrastructure.Entities
{
    public class ValidationFailureResponse : IValidationFailureResponse
    {
        public string Type { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
