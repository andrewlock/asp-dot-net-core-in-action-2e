using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RecipeApplication
{
    public class EnsureRecipeExistsAttribute : TypeFilterAttribute
    {
        public EnsureRecipeExistsAttribute() : base(typeof(EnsureRecipeExistsFilter)) { }

        public class EnsureRecipeExistsFilter : IAsyncActionFilter
        {
            private readonly RecipeService _service;
            public EnsureRecipeExistsFilter(RecipeService service)
            {
                _service = service;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
            {
                var recipeId = (int)context.ActionArguments["id"];
                if (!await _service.DoesRecipeExistAsync(recipeId))
                {
                    context.Result = new NotFoundResult();
                }
                else
                {
                    await next();
                }
            }
        }
    }
}
