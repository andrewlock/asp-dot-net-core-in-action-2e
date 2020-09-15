using Microsoft.AspNetCore.Authorization;

namespace RecipeApplication.Authorization
{
    public class IsRecipeOwnerRequirement : IAuthorizationRequirement { }
}