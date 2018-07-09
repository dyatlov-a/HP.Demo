using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HP.Demo.Domain.Models.Identity;
using HP.Demo.Dtos.UsersRead;
using HP.Demo.Dtos.UsersWrite;
using HP.Demo.Services.Contracts;
using HP.Demo.Web.Infrastructure;
using HP.Demo.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HP.Demo.Web.Controllers
{
    public class UsersController : BaseV1Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet, FunctionalAuthorizeFilter(Functional.UserShow)]
        public async Task<IEnumerable<UserDto>> Get()
        {
            return await _userService.GetAllAsync();
        }

        [HttpPost, FunctionalAuthorizeFilter(Functional.UserCreate)]
        public async Task Create([FromBody]UserCreateDto userCreateDto)
        {
            await _userService.CreateAsync(userCreateDto);
        }

        [HttpPut("{userId}"), FunctionalAuthorizeFilter(Functional.UserEdit)]
        public async Task Update(Guid userId, [FromBody]UserEditDto userEditDto)
        {
            await _userService.UpdateAsync(userId, userEditDto);
        }

        [HttpDelete("{userId}"), FunctionalAuthorizeFilter(Functional.UserRemove)]
        public async Task Delete(Guid userId)
        {
            await _userService.RemoveAsync(userId);
        }
    }
}
