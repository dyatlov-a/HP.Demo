using System;
using System.Collections.Generic;
using System.Linq;
using HP.Demo.Domain.DataContracts;
using HP.Demo.Domain.Extensions;

namespace HP.Demo.Domain.Models.Identity
{
    public class User : Entity, IPassword
    {
        public string Email { get; private set; }
        public byte[] Salt { get; private set; }
        public byte[] Hash { get; private set; }

        private ICollection<UserGroup> UserGroups { get; } = new List<UserGroup>();

        public IEnumerable<Group> Groups => UserGroups.Select(ug => ug.Group);

        private User()
        {
        }

        public User(string email, IPassword password)
            : this()
        {
            if (email.IsNullOrWhiteSpace())
                throw new ArgumentException(nameof(email));
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            UpdateEmail(email);
            RefreshPassword(password);
        }

        public void RefreshPassword(IPassword password)
        {
            if (password == null)
                throw new ArgumentNullException(nameof(password));

            Salt = password.Salt;
            Hash = password.Hash;
        }

        public void UpdateEmail(string email)
        {
            if (email.IsNullOrWhiteSpace())
                throw new ArgumentException(nameof(email));

            Email = email;
        }

        public void AddGroupToUser(Group group)
        {
            if (group == null)
                throw new ArgumentNullException(nameof(group));

            if (Groups.Contains(group))
                return;

            UserGroups.Add(new UserGroup(group, this));
        }

        public void RemoveGroupFromUser(Group group)
        {
            if (group == null)
                throw new ArgumentNullException(nameof(group));

            if (group.IsReadonly())
                throw new ApplicationException($"You can't remove group {group.Name}");

            if (!Groups.Contains(group))
                return;

            var targetUserGroup = UserGroups.Single(ug => ug.Group.Id == group.Id);
            UserGroups.Remove(targetUserGroup);
        }
    }
}
