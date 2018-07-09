using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace HP.Demo.Domain.Models.Identity.Specifications
{
    public class GroupByTypeSpec : Specification<Group>
    {
        private readonly GroupType _groupType;

        public GroupByTypeSpec(GroupType groupType)
        {
            _groupType = groupType;
        }

        public override Expression<Func<Group, bool>> ToExpression()
        {
            return g => g.GroupType == _groupType;
        }
    }
}
