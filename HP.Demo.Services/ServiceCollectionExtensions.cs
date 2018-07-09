using System;
using HP.Demo.Services.Contracts;
using HP.Demo.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace HP.Demo.Services
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IClaimProvider, ClaimProvider>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IGroupAddLogic, GroupAddLogic>();
            services.AddTransient<IGroupService, GroupService>();
        }
    }
}
