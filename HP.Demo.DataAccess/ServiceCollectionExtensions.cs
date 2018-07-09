using System;
using HP.Demo.DataAccess.Contexts;
using HP.Demo.DataAccess.Data;
using HP.Demo.DataAccess.Implementations;
using HP.Demo.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HP.Demo.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataAccess(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            if (optionsAction == null)
                throw new ArgumentNullException(nameof(optionsAction));

            services.AddDbContext<UserContext>(optionsAction);
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDataInit, DefaultDataInit>();
        }
    }
}
