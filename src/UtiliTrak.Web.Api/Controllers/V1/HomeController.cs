using System;
using System.Linq;
using System.Collections.Generic;
using Hazeltek.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Hazeltek.UtiliTrak.Web.Common.Routing;



namespace Hazeltek.UtiliTrak.Web.Api.Controllers.V1
{
    [ApiVersion1Route("")]
    public class HomeController: Controller
    {
        // fields:
        private Type[] rootControllers = null;

        public IEnumerable<string> GetRootApi()
        {
            if (rootControllers == null) {
                var typeFinder = new AppProcessTypeFinder();
                var types = typeFinder.FindClassesOfType(typeof(Controller));
                
                IList<Type> root = new List<Type>();
                foreach (var type in types) {
                    if (type.Name == "HomeController") continue;
                    root.Add(type);
                }
                rootControllers = root.ToArray();
            }

            IList<string> rootUrls = new List<string>();
            var urlFormat = "api/v1/{0}/";

            foreach (var type in rootControllers) {
                rootUrls.Add(string.Format(urlFormat, type.Name.ToLower().Replace("controller","")));
            }
            return rootUrls.ToArray();
        }
    }


}