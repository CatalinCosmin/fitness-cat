namespace Core.Abstractions.Entities
{
    public interface IValidationFailureResponse
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
