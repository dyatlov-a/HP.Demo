using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HP.Demo.Domain.Contracts;
using HP.Demo.Domain.Models.Identity;
using HP.Demo.Domain.Models.Identity.Specifications;
using HP.Demo.Dtos.UsersRead;
using HP.Demo.Dtos.UsersWrite;
using HP.Demo.Services.Contracts;

namespace HP.Demo.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IProjectionBuilder _projectionBuilder;
        private readonly IHashService _hashService;
        private readonly IGroupAddLogic _groupAddLogic;

        public UserService(IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            IProjectionBuilder projectionBuilder,
            IHashService hashService,
            IGroupAddLogic groupAddLogic)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _projectionBuilder = projectionBuilder ?? throw new ArgumentNullException(nameof(projectionBuilder));
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
            _groupAddLogic = groupAddLogic ?? throw new ArgumentNullException(nameof(groupAddLogic));
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var results = _projectionBuilder.Build<IEnumerable<User>, IEnumerable<UserDto>>(users);
            return results;
        }

        public Task CreateAsync(UserCreateDto userCreateDto)
        {
            if (userCreateDto == null)
                throw new ArgumentNullException(nameof(userCreateDto));

            return CreateAsyncAction(userCreateDto);
        }

        private async Task CreateAsyncAction(UserCreateDto userCreateDto)
        {
            var password = _hashService.Hash(userCreateDto.Password);
            var user = new User(userCreateDto.Email, password);
            await _groupAddLogic.UserAddToGroupsAsync(user, new GroupIsDefaultSpec());
            _userRepository.Insert(user);
            await _unitOfWork.SaveAsync();
        }

        public Task UpdateAsync(Guid userId, UserEditDto userEditDto)
        {
            if (userEditDto == null)
                throw new ArgumentNullException(nameof(userEditDto));

            return UpdateAsyncAction(userId, userEditDto);
        }

        private async Task UpdateAsyncAction(Guid userId, UserEditDto userEditDto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            user.UpdateEmail(userEditDto.Email);
            _userRepository.Update(user);
            await _unitOfWork.SaveAsync();
        }

        public async Task RemoveAsync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            _userRepository.Remove(user);
            await _unitOfWork.SaveAsync();
        }
    }
}
