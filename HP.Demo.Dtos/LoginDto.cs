using System.ComponentModel.DataAnnotations;
using HP.Demo.Domain.DataContracts;

namespace HP.Demo.Dtos
{
    public class LoginDto
    {
        [Required, EmailAddress, MaxLength(Constraints.EmailMaxLength)]
        public string Email { get; set; }

        [Required, MinLength(Constraints.PasswordMinLength)]
        public string Password { get; set; }
    }
}
