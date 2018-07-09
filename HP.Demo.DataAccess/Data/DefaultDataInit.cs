using System;
using HP.Demo.Domain.Models.Identity;
using HP.Demo.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HP.Demo.DataAccess.Data
{
    public class DefaultDataInit : IDataInit
    {
        private readonly IHashService _hashService;

        public DefaultDataInit(IHashService hashService)
        {
            _hashService = hashService ?? throw new ArgumentNullException(nameof(hashService));
        }

        public void Seed(ModelBuilder modelBuilder)
        {
            var usersGroup = new
            {
                Id = new Guid("5d52ad35-a76b-427d-a5b2-0a650e285644"),
                Name = "Users",
                GroupType = GroupType.Default,
                Functionals = Functional.UserShow
            };
            modelBuilder.Entity<Group>().HasData(usersGroup);
            
            var adminsGroup = new
            {
                Id = new Guid("cdba21fe-cbe9-4939-8ff4-e1854e574c22"),
                Name = "Admins",
                GroupType = GroupType.Custom,
                Functionals = Functional.UserCreate
                              | Functional.UserEdit
                              | Functional.UserRemove
                              | Functional.UserAddToGroup
                              | Functional.UserRemoveFromGroup
            };
            modelBuilder.Entity<Group>().HasData(adminsGroup);

            var adminPassword = _hashService.Hash("12345678");
            var admin = new
            {
                Id = new Guid("b13f0125-3252-4f3c-9721-43b88ece43e5"),
                Email = "admin@admin.ru",
                Salt = adminPassword.Salt,
                Hash = adminPassword.Hash
            };
            modelBuilder.Entity<User>().HasData(admin);
            modelBuilder.Entity<UserGroup>().HasData(new
            {
                GroupId = usersGroup.Id,
                UserId = admin.Id
            });
            modelBuilder.Entity<UserGroup>().HasData(new
            {
                GroupId = adminsGroup.Id,
                UserId = admin.Id
            });
        }
    }
}
