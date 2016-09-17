using Microsoft.AspNetCore.Mvc;


namespace Hazeltek.UtiliTrak.Web.Common.Routing
{
    public class ApiVersion1RouteAttribute: RouteAttribute
    {
        private const string RouteBase = "api/{apiVersion:apiVersionConstraint(v1)}";
        private const string PrefixRouteBase = RouteBase + "/";


        public ApiVersion1RouteAttribute(string routePrefix): base(
                string.IsNullOrWhiteSpace(routePrefix)
                      ? RouteBase : PrefixRouteBase + routePrefix)
        {
        }
    }


}