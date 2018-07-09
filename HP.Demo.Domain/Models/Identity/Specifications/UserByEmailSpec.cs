using System;
using System.Linq.Expressions;
using LinqSpecs;

namespace HP.Demo.Domain.Models.Identity.Specifications
{
    public class UserByEmailSpec : Specification<User>
    {
        private readonly string _email;

        public UserByEmailSpec(string email)
        {
            _email = email;
        }

        public override Expression<Func<User, bool>> ToExpression()
        {
            return e => e.Email == _email;
        }
    }
}
