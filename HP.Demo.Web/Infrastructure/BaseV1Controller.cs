using HP.Demo.Web.Infrastructure.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HP.Demo.Web.Infrastructure
{
    [Route("api/"+ Version + "/[controller]"), ModelStateValidationFilter]
    public abstract class BaseV1Controller : Controller
    {
        public const string Version = "v1";
    }
}
