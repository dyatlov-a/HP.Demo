using System;
using HP.Demo.Domain.DataContracts;
using HP.Demo.Domain.Extensions;
using HP.Demo.Domain.Models.Identity.Specifications;

namespace HP.Demo.Domain.Models.Identity
{
    public class Group : Entity
    {
        public string Name { get; private set; }
        public GroupType GroupType { get; private set; }
        public Functional Functionals { get; private set; }

        private Group()
        {
        }

        public Group(string name, GroupType groupType, Functional functionals)
            : this()
        {
            if (name.IsNullOrWhiteSpace())
                throw new ArgumentNullException(nameof(name));

            Name = name;
            GroupType = groupType;
            Functionals = functionals;
        }

        public bool IsReadonly()
        {
            return new GroupIsDefaultSpec().Eval(this);
        }
    }
}
