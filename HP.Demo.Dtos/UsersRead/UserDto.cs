using System;
using System.Collections.Generic;

namespace HP.Demo.Dtos.UsersRead
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<GroupDto> Groups { get; set; }
    }
}
