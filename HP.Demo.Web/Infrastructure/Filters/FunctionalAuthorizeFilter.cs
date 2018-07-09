using System;
using System.Net;
using HP.Demo.Domain.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HP.Demo.Web.Infrastructure.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class FunctionalAuthorizeFilter : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly Functional _functional;

        public FunctionalAuthorizeFilter(Functional functional)
        {
            _functional = functional;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return;
            }

            var isAuthorized = user.HasClaim(nameof(Functional), _functional.ToString());
            if (!isAuthorized)
            {
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
            }
        }
    }
}
