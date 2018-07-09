using System;
using HP.Demo.Domain.Contracts;
using HP.Demo.Services.Contracts;
using HP.Demo.Web.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace HP.Demo.Web.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddTransient<IProjectionBuilder, ProjectionBuilder>();
            services.AddTransient<ITokenFactory, TokenFactory>();
        }
    }
}
