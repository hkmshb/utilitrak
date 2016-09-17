using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Hazeltek.UtiliTrak.Web.Common.Routing
{
    public class ApiVersionRouteConstraint: IRouteConstraint
    {
        public ApiVersionRouteConstraint(string allowedVersion)
        {
            AllowedVersion = allowedVersion.ToLowerInvariant();
        }

        public string AllowedVersion { get; private set; }

        public bool Match(HttpContext httpContext, IRouter route,
               string routeKey, RouteValueDictionary values,
               RouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(routeKey, out value) && value != null) {
                return AllowedVersion.Equals(value.ToString().ToLowerInvariant());
            }
            return false;
        }
    }


}