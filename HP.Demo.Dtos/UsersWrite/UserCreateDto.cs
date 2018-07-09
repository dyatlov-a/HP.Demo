using System.ComponentModel.DataAnnotations;
using HP.Demo.Domain.DataContracts;

namespace HP.Demo.Dtos.UsersWrite
{
    public class UserCreateDto
    {
        [Required, EmailAddress, MaxLength(Constraints.EmailMaxLength)]
        public string Email { get; set; }

        [Required, MinLength(Constraints.PasswordMinLength)]
        public string Password { get; set; }
    }
}
