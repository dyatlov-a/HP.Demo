using System.Collections.Generic;
using HP.Demo.DataAccess;
using HP.Demo.Security;
using HP.Demo.Security.Common;
using HP.Demo.Services;
using HP.Demo.Web.Infrastructure;
using HP.Demo.Web.Infrastructure.Auth;
using HP.Demo.Web.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace HP.Demo.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var securityOptions = _configuration.GetSection(nameof(SecurityOptions)).Get<SecurityOptions>();
            services.AddSingleton(securityOptions);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = securityOptions.ValidateIssuer,
                        ValidIssuer = securityOptions.Issuer,
                        ValidateAudience = false,
                        ValidateLifetime = securityOptions.ValidateLifetime,
                        IssuerSigningKey = securityOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = securityOptions.ValidateIssuerSigningKey
                    };
                });

            services.AddMvc();
            services.AddDataAccess(o => o.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddServices();
            services.AddInfrastructureServices();
            services.AddSecurity(() => _configuration.GetSection(nameof(HashOptions)).Get<HashOptions>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = securityOptions.Issuer, Version = "v1" });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } }
                });
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "Authorization: Bearer {token}",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMiddleware<UnhandledExceptionsLoggingMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseSwagger()
                   .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HP.Demo.Web API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
