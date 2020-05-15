using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class GlobalLogAsyncAuthorizationFilter : Attribute, IAsyncAuthorizationFilter
    {
        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            Console.WriteLine("Executing GlobalLogAsyncAuthorizationFilter.OnAuthorization");
            //context.AuthorizationHandled = true;
            //context.Result = new ContentResult()
            //{
            //    Content = "I handled it!"
            //};
            return Task.CompletedTask;
        }
    }
}
