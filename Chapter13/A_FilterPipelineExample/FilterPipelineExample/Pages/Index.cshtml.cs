using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilterPipelineExample.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FilterPipelineExample.Pages
{
    [LogResourceFilter]
    [LogActionFilter] // Will not do anything on Razor Pages
    [LogPageFilter]
    [LogAuthorizationFilter]
    [LogResultFilter]
    [LogAlwaysRunResultFilter]
    [LogExceptionFilter]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Console.WriteLine("Executing Index.OnGet");
        }
        public void OnGetException()
        {
            Console.WriteLine("Executing Index.OnGetException");
            throw new Exception("Exception thrown!");
        }

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            Console.WriteLine("Executing Index.OnPageHandlerSelected");
        }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            Console.WriteLine("Executing Index.OnPageHandlerExecuting");
            //context.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncPageFilter - Short-circuiting ",
            //};
        }

        public override void OnPageHandlerExecuted(PageHandlerExecutedContext context)
        {
            Console.WriteLine($"Executing Index.OnPageHandlerExecuted: cancelled {context.Canceled}");
            //executedContext.ExceptionHandled = true;
            //executedContext.Result = new ContentResult()
            //{
            //    Content = "GlobalLogAsyncPageFilter - convert to success ",
            //};
        }
    }
}