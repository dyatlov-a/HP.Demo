using AutoMapper;
using HP.Demo.Domain.Models.Identity;
using HP.Demo.Dtos.UsersRead;

namespace HP.Demo.Web.Infrastructure
{
    public class UsersReadProfile : Profile
    {
        public UsersReadProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<Group, GroupDto>();
        }
    }
}
