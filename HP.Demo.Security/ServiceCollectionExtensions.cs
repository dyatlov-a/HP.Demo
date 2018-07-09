using Microsoft.Extensions.DependencyInjection;
using System;
using HP.Demo.Security.Common;
using HP.Demo.Security.Implementations;
using HP.Demo.Services.Contracts;

namespace HP.Demo.Security
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSecurity(this IServiceCollection services, Func<HashOptions> hashOptionsFunc)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(hashOptionsFunc());
            services.AddSingleton<IHashService, HashService>();
        }
    }
}
