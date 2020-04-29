using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApiProject.Controllers
{
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly List<string> _fruit = new List<string>
            {
                "Pear",
                "Lemon",
                "Peach"
            };

        [HttpGet("fruit")]
        public IEnumerable<string> Index()
        {
            return _fruit;
        }

        [HttpGet("fruit/{id}")]
        public ActionResult<string> View(int id)
        {
            if (id >= 0 && id < _fruit.Count)
            {
                return _fruit[id];
            }

            return NotFound();
        }
    }
}
