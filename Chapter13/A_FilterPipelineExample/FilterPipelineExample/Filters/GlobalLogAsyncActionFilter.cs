using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class GlobalLogAsyncActionFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine("Executing GlobalLogAsyncActionFilter - before");
            //context.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncActionFilter - Short-circuiting ",
            //};

            var executedContext = await next();

            Console.WriteLine($"Executing GlobalLogAsyncActionFilter - after: cancelled {executedContext.Canceled}");
            //executedContext.ExceptionHandled = true;
            //executedContext.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncActionFilter - convert to success ",
            //};
        }
    }
}
