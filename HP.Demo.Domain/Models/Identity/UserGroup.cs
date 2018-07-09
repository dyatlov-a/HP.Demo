using System;

namespace HP.Demo.Domain.Models.Identity
{
    public class UserGroup
    {
        public Guid GroupId { get; private set; }
        public Group Group { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        private UserGroup()
        {
        }

        public UserGroup(Group group, User user)
            : this()
        {
            Group = group ?? throw new ArgumentNullException(nameof(group));
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
