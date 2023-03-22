using Core.Abstractions.Entities;
using System.ComponentModel.DataAnnotations;

namespace Api.Requests
{
    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Required] 
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Recaptcha { get; set; } = string.Empty;
    }
}
