using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class GlobalLogAsyncResourceFilter : Attribute, IAsyncResourceFilter
    {
        public async Task OnResourceExecutionAsync(
            ResourceExecutingContext context,
            ResourceExecutionDelegate next)
        {
            Console.WriteLine("Executing GlobalLogAsyncResourceFilter - before");
            //context.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncResourceFilter - Short-circuiting ",
            //};

            var executedContext = await next();

            Console.WriteLine($"Executing GlobalLogAsyncResourceFilter - after: cancelled {executedContext.Canceled}");
        }
    }
}
