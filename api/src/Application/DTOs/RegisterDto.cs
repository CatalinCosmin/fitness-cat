using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class RegisterDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public DateOnly AccountCreationDate { get; set; }
    }
}
