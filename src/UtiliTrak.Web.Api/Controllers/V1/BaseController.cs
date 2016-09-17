using System;
using Microsoft.AspNetCore.Mvc;
using Hazeltek.Infrastructure;
using Hazeltek.UtiliTrak.Web.Common.TypeMapping;



namespace Hazeltek.UtiliTrak.Web.Api.Controllers.V1
{
    public abstract class BaseController: Controller
    {
        protected IAutoMapper Mapper
        {
            get {
                return EngineContext.Current.Resolve<IAutoMapper>();
            }
        }
        
        protected IActionResult Process(Func<IActionResult> action)
        {
            try {
                if (ModelState.IsValid) {
                    return action();
                }
                return BadRequest(new { Errors = ModelState.Values });
            } catch (Exception ex) {
                return BadRequest(new { Errors = ex.ToString() });
            }
        }
    }


}