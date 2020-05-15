using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class GlobalLogAsyncResultFilter : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            Console.WriteLine("Executing GlobalLogAsyncResultFilter - before");
            //context.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncResultFilter - Short-circuiting ",
            //};

            var executedContext = await next();

            Console.WriteLine($"Executing GlobalLogAsyncResultFilter - after: cancelled {executedContext.Canceled}");
        }
    }
}
