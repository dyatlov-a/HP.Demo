using System.ComponentModel.DataAnnotations;
using HP.Demo.Domain.DataContracts;

namespace HP.Demo.Dtos.UsersWrite
{
    public class UserEditDto
    {
        [Required, EmailAddress, MaxLength(Constraints.EmailMaxLength)]
        public string Email { get; set; }
    }
}
