using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecipeApplication.Data;
using RecipeApplication.Models;

namespace RecipeApplication.Pages.Recipes
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public UpdateRecipeCommand Input { get; set; }
        private readonly RecipeService _service;

        public EditModel(RecipeService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnGet(int id)
        {

            Input = await _service.GetRecipeForUpdate(id);
            if (Input is null)
            {
                // If id is not for a valid Recipe, generate a 404 error page
                // TODO: Add status code pages middleware to show friendly 404 page
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.UpdateRecipe(Input);
                    return RedirectToPage("View", new { id = Input.Id });
                }
            }
            catch (Exception)
            {
                // TODO: Log error
                // Add a model-level error by using an empty string key
                ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the recipe"
                    );
            }

            //If we got to here, something went wrong
            return Page();
        }
    }
}