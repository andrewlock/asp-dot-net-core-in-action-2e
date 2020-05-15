using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class LogPageFilter : Attribute, IPageFilter
    {
        public void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            Console.WriteLine("Executing IPageFilter.OnPageHandlerSelected");
        }

        public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Console.WriteLine("Executing IPageFilter.OnPageHandlerExecuting");
            //context.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncPageFilter - Short-circuiting ",
            //};
        }

        public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            Console.WriteLine($"Executing IPageFilter.OnPageHandlerExecuted: cancelled {context.Canceled}");
            //executedContext.ExceptionHandled = true;
            //executedContext.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncPageFilter - convert to success ",
            //};
        }
    }
}
