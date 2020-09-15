using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeApplication.Data;
using RecipeApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeApplication.ViewComponents
{
    public class MyRecipesViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public MyRecipesViewComponent(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int numberOfRecipes)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("Unauthenticated");
            }
            var userId = _userManager.GetUserId(HttpContext.User);
            var recipes = await _context.Recipes
                .Where(x => x.CreatedById == userId)
                .OrderBy(x => x.LastModified)
                .Take(numberOfRecipes)
                .Select(x => new RecipeSummaryViewModel
                {
                    Id = x.RecipeId,
                    Name = x.Name,
                })
                .ToListAsync();

            return View(recipes);
        }
    }
}
