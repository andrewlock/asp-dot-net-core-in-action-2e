using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class LogExceptionFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Console.WriteLine("Executing IExceptionFilter.OnException");
            //context.ExceptionHandled = true;
            //context.Result = new ContentResult()
            //{
            //    Content = "I handled it!"
            //};
        }
    }
}
