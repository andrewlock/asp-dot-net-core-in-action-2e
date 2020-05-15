using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RecipeApplication.Models;

namespace RecipeApplication
{
    public class AddLastModifedHeaderAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is OkObjectResult result
                && result.Value is RecipeDetailViewModel detail)
            {
                var lastModified = context.HttpContext.Request
                    .GetTypedHeaders().IfModifiedSince;

                if (lastModified.HasValue
                    && lastModified >= detail.LastModified)
                {
                    context.Result = new StatusCodeResult(304);
                }

                context.HttpContext.Response.GetTypedHeaders().LastModified
                    = detail.LastModified;
            }
        }
    }
}
