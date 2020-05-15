using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApplication.Models;

namespace RecipeApplication.Controllers
{
    [Route("api/nofilters")]
    public class NoFiltersApiController : ControllerBase
    {
        private const bool IsEnabled = true;
        private readonly IPAddress[] _allowedAddress =
        {
            IPAddress.Parse("127.0.0.1"),
            IPAddress.Parse("::1"),
        };

        public RecipeService _service;
        public NoFiltersApiController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var ipAddress = HttpContext
                .Connection.RemoteIpAddress;
            if (!_allowedAddress.Contains(ipAddress))
            {
                return Forbid();
            }

            if (!IsEnabled) { return BadRequest(); }

            try
            {
                if (!await _service.DoesRecipeExistAsync(id))
                {
                    return NotFound();
                }

                var detail = await _service.GetRecipeDetail(id);

                var lastModified =
                    Request.GetTypedHeaders().IfModifiedSince;
                if (lastModified.HasValue)
                {
                    if (lastModified >= detail.LastModified)
                    {
                        return StatusCode(304);
                    }
                }

                Response.GetTypedHeaders().LastModified =
                    detail.LastModified;

                return Ok(detail);
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditAsync(
            int id, [FromBody] UpdateRecipeCommand command)
        {
            var ipAddress = HttpContext
                .Connection.RemoteIpAddress;
            if (!_allowedAddress.Contains(ipAddress))
            {
                return Forbid();
            }

            if (!IsEnabled) { return BadRequest(); }

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!await _service.DoesRecipeExistAsync(id))
                {
                    return NotFound();
                }

                await _service.UpdateRecipe(command);
                return Ok();
            }
            catch (Exception ex)
            {
                return GetErrorResponse(ex);
            }
        }

        private static IActionResult GetErrorResponse(Exception ex)
        {
            var error = new ProblemDetails
            {
                Title = "An error occured",
                Detail = ex.Message,
                Status = 500,
                Type = "https://httpstatuses.com/500"
            };

            return new ObjectResult(error)
            {
                StatusCode = 500
            };
        }
    }
}