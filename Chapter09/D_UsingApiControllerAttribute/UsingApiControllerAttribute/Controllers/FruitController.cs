using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace UsingApiControllerAttribute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FruitController : ControllerBase
    {
        List<string> _fruit = new List<string>
        {
            "Pear", "Lemon", "Peach"
        };

        [HttpGet]
        public ActionResult Update()
        {
            return Ok(_fruit);
        }

        [HttpPost]
        public ActionResult Update(UpdateModel model)
        {
            if (model.Id < 0 || model.Id > _fruit.Count)
            {
                return NotFound();
            }

            _fruit[model.Id] = model.Name;
            return Ok();
        }
    }
}
