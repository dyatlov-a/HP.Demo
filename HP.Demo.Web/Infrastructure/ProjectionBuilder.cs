using AutoMapper;
using HP.Demo.Domain.Contracts;

namespace HP.Demo.Web.Infrastructure
{
    public class ProjectionBuilder : IProjectionBuilder
    {
        static ProjectionBuilder()
        {
            Mapper.Initialize(c => c.AddProfile<UsersReadProfile>());
        }

        public TProjection Build<TValue, TProjection>(TValue value)
        {
            var result = Mapper.Map<TValue, TProjection>(value);
            return result;
        }
    }
}
