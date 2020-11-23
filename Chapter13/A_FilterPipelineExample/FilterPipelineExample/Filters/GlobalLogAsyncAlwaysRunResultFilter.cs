using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{

    public class GlobalLogAsyncAlwaysRunResultFilter : Attribute, IAsyncAlwaysRunResultFilter
    {
        public async Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            Console.WriteLine("Executing GlobalLogAsyncAlwaysRunResultFilter - before");
            //context.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncAlwaysRunResultFilter - Short-circuiting ",
            //};

            var executedContext = await next();

            Console.WriteLine($"Executing GlobalLogAsyncAlwaysRunResultFilter - after: cancelled {executedContext.Canceled}");
        }
    }
}
