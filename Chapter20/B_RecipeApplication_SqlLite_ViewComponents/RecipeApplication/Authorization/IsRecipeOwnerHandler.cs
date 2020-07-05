using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using RecipeApplication.Data;

namespace RecipeApplication.Authorization
{
    public class IsRecipeOwnerHandler :
        AuthorizationHandler<IsRecipeOwnerRequirement, Recipe>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IsRecipeOwnerHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            IsRecipeOwnerRequirement requirement,
            Recipe resource)
        {
            var appUser = await _userManager.GetUserAsync(context.User);
            if (appUser == null)
            {
                return;
            }

            if (resource.CreatedById == appUser.Id)
            {
                context.Succeed(requirement);
            }
        }
    }
}