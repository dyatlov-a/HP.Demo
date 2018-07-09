using System;
using System.Threading.Tasks;
using HP.Demo.Domain.Contracts;
using HP.Demo.Domain.Models.Identity.Specifications;
using HP.Demo.Services.Contracts;

namespace HP.Demo.Services.Implementations
{
    public class GroupService : IGroupService
    {
        private readonly IUserRepository _userRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupAddLogic _groupAddLogic;

        public GroupService(IUserRepository userRepository, 
            IGroupRepository groupRepository,
            IUnitOfWork unitOfWork,
            IGroupAddLogic groupAddLogic)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _groupRepository = groupRepository ?? throw new ArgumentNullException(nameof(groupRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _groupAddLogic = groupAddLogic ?? throw new ArgumentNullException(nameof(groupAddLogic));
        }

        public async Task AddToAdminAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            await _groupAddLogic.UserAddToGroupsAsync(user, !new GroupIsDefaultSpec());
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveFromAdminAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var adminGroups = await _groupRepository.GetBySpecAsync(!new GroupIsDefaultSpec());
            foreach (var adminGroup in adminGroups)
            {
                user.RemoveGroupFromUser(adminGroup);
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
