using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RecipeApplication
{
    public class HandleExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var error = new ProblemDetails
            {
                Title = "An error occured",
                Detail = context.Exception.Message,
                Status = 500,
                Type = "https://httpstatuses.com/500"
            };

            context.Result = new ObjectResult(error)
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }
}
