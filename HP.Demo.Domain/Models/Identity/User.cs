using System;
using System.Collections.Generic;
using System.Linq;
using HP.Demo.Domain.DataContracts;

namespace HP.Demo.Domain.Models.Identity
{
    public class User : Entity, IPassword
    {
        public string Email { get; private set; }
        public byte[] Salt { get; private set; }
        public byte[] Hash { get; private set; }

        private readonly ICollection<UserGroup> _userGroups;

        public IEnumerable<Group> Groups => _userGroups.Select(ug => ug.Group);

        private User()
        {
            _userGroups = new HashSet<UserGroup>();
        }

        public User(string email, IPassword password)
            : this()
        {
            if (String.IsNullOrWhiteSpace(email))
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
            if (String.IsNullOrWhiteSpace(email))
                throw new ArgumentException(nameof(email));

            Email = email;
        }

        public void AddGroupToUser(Group group)
        {
            if (group == null)
                throw new ArgumentNullException(nameof(group));

            if (Groups.Contains(group))
                return;

            _userGroups.Add(new UserGroup(group, this));
        }

        public void RemoveGroupFromUser(Group group)
        {
            if (group == null)
                throw new ArgumentNullException(nameof(group));

            if (group.IsReadonly())
                throw new ApplicationException($"You can't remove group {group.Name}");

            if (!Groups.Contains(group))
                return;

            var targetUserGroup = _userGroups.Single(ug => ug.Group.Id == group.Id);
            _userGroups.Remove(targetUserGroup);
        }
    }
}
