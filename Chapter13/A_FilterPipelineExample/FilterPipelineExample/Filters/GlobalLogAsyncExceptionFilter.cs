using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class GlobalLogAsyncExceptionFilter : Attribute, IAsyncExceptionFilter
    {
        public Task OnExceptionAsync(ExceptionContext context)
        {
            Console.WriteLine($"Executing GlobalLogAsyncExceptionFilter.OnException: handled {context.ExceptionHandled}");
            //context.ExceptionHandled = true;
            //context.Result = new ContentResult()
            //{
            //    Content = "I handled it!"
            //};
            return Task.CompletedTask;
        }
    }
}
