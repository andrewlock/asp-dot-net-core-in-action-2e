using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Models;

namespace RecipeApplication.Controllers
{
    [Route("api/recipe")]
    [ValidateModel, HandleException, FeatureEnabled(IsEnabled = true)]
    public class RecipeApiController : ControllerBase
    {
        public RecipeService _service;
        public RecipeApiController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet("{id}"), EnsureRecipeExists, AddLastModifedHeader]
        public async Task<IActionResult> Get(int id)
        {
            var detail = await _service.GetRecipeDetail(id);
            return Ok(detail);

        }

        [HttpPost("{id}"), EnsureRecipeExists, RequireIpAddress]
        public async Task<IActionResult> Edit(int id, [FromBody] UpdateRecipeCommand command)
        {
            await _service.UpdateRecipe(command);
            return Ok();
        }
    }
}
