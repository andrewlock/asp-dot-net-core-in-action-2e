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
                // If the LastModified header has been sent with the request, we can
                // check to see if is the same (or later) than the view model's date
                // If it is, then we can tell the browser "it's the same" using a 304 response
                // and avoid the cost associated with serializing and sending the model
                var viewModelDate = detail.LastModified;
                var lastModified = context.HttpContext.Request
                    .GetTypedHeaders().IfModifiedSince;

                if (lastModified.HasValue
                    && lastModified >= detail.LastModified)
                {
                    context.Result = new StatusCodeResult(304);
                }

                context.HttpContext.Response.GetTypedHeaders().LastModified = viewModelDate;
            }
        }
    }
}
