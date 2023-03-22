using System.ComponentModel.DataAnnotations;

namespace Api.Requests
{
    public class RegisterRequestDto
    {
        public Guid ID { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public DateOnly BirthDate { get; set; } // Format "YYYY-MM-DDThh:mm:ss"
        public DateOnly AccountCreationDate { get; set; }
        public DateTime? LastAuthenticationDate { get; set; }
        public bool isVerified { get; set; } = false;

        [Required]
        public string Recaptcha { get; set; } = string.Empty;
    }
}
