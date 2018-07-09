using System;
using LinqSpecs;

namespace HP.Demo.Domain.Extensions
{
    public static class SpecificationExtensions
    {
        public static bool Eval<T>(this Specification<T> specification, T obj)
        {
            if (specification == null)
                throw new ArgumentNullException(nameof(specification));
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            return specification.ToExpression().Compile()(obj);
        }
    }
}
