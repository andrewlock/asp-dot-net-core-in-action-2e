using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class LogActionFilter : Attribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Executing IActionFilter.OnActionExecuting");
            //context.Result = new ContentResult()
            //{
            //    Content = "IActionFilter - Short-circuiting ",
            //};
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"Executing IActionFilter.OnActionExecuted: cancelled {context.Canceled}");
            //context.ExceptionHandled = true;
            //context.Result = new ContentResult()
            //{
            //    Content = "IActionFilter - convert to success ",
            //};
        }
    }
}
