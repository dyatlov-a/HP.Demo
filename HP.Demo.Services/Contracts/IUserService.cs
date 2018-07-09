using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HP.Demo.Dtos.UsersRead;
using HP.Demo.Dtos.UsersWrite;

namespace HP.Demo.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task CreateAsync(UserCreateDto userCreateDto);
        Task UpdateAsync(Guid userId, UserEditDto userEditDto);
        Task RemoveAsync(Guid userId);
    }
}
