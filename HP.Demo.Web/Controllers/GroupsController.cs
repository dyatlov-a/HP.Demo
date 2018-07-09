using System;
using System.Threading.Tasks;
using HP.Demo.Domain.Models.Identity;
using HP.Demo.Services.Contracts;
using HP.Demo.Web.Infrastructure;
using HP.Demo.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HP.Demo.Web.Controllers
{
    public class GroupsController : BaseV1Controller
    {
        private readonly IGroupService _groupService;

        public GroupsController(IGroupService groupService)
        {
            _groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        [HttpPatch("{userId}/AddToAdmin"), FunctionalAuthorizeFilter(Functional.UserAddToGroup)]
        public async Task AddToAdmin(Guid userId)
        {
            await _groupService.AddToAdminAsync(userId);
        }

        [HttpPatch("{userId}/RemoveFromAdmin"), FunctionalAuthorizeFilter(Functional.UserRemoveFromGroup)]
        public async Task RemoveFromAdmin(Guid userId)
        {
            await _groupService.RemoveFromAdminAsync(userId);
        }
    }
}
