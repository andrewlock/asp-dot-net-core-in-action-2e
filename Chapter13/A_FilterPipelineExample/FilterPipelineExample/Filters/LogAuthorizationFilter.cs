using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class LogAuthorizationFilter : Attribute , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Console.WriteLine("Executing IAuthorizationFilter.OnAuthorization");
            //context.Result = new ContentResult()
            //{
            //    Content = "IAuthorizationFilter - Short-circuiting ",
            //};
        }
    }
}
