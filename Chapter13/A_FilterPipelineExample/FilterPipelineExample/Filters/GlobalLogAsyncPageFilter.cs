using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class GlobalLogAsyncPageFilter : Attribute, IAsyncPageFilter
    {
        public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        {
            Console.WriteLine("Executing GlobalLogAsyncPageFilter - after handler selection");
            return Task.CompletedTask;
        }

        public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context, PageHandlerExecutionDelegate next)
        {
            Console.WriteLine("Executing GlobalLogAsyncPageFilter - before handler execution");
            //context.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncPageFilter - Short-circuiting ",
            //};

            var executedContext = await next();

            Console.WriteLine($"Executing GlobalLogAsyncPageFilter - after handler execution: cancelled {executedContext.Canceled}");
            //executedContext.ExceptionHandled = true;
            //executedContext.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncPageFilter - convert to success ",
            //};
        }
    }
}
