using System;

namespace HP.Demo.Domain.Models.Identity
{
    [Flags]
    public enum Functional
    {
        UserShow = 1,
        UserCreate = 2,
        UserEdit = 4,
        UserRemove = 8,
        UserAddToGroup = 16,
        UserRemoveFromGroup = 32
    }
}
