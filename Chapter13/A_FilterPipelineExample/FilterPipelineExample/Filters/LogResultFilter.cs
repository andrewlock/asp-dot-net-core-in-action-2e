using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPipelineExample.Filters
{
    public class LogResultFilter : Attribute, IResultFilter
    {
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Executing IResultFilter.OnResultExecuting");
            //context.Cancel = true;
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Executing IResultFilter.OnResultExecuted");
        }
    }
}
