using System;
using System.Threading.Tasks;
using HP.Demo.Domain.Contracts;
using HP.Demo.Domain.Models.Identity;
using HP.Demo.Services.Contracts;
using LinqSpecs;

namespace HP.Demo.Services.Implementations
{
    public class GroupAddLogic : IGroupAddLogic
    {
        private readonly IGroupRepository _groupRepository;

        public GroupAddLogic(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
        }

        public Task UserAddToGroupsAsync(User user, Specification<Group> spec)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (spec == null)
                throw new ArgumentNullException(nameof(spec));

            return UserAddToGroupsActionAsync(user, spec);
        }

        private async Task UserAddToGroupsActionAsync(User user, Specification<Group> spec)
        {
            var adminGroups = await _groupRepository.GetBySpecAsync(spec);
            foreach (var adminGroup in adminGroups)
            {
                user.AddGroupToUser(adminGroup);
            }
        }
    }
}
