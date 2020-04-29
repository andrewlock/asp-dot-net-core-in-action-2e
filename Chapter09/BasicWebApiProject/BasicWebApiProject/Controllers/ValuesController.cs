using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BasicWebApiProject.Controllers
{
    public class FruitController : Controller
    {
        private readonly List<string> _fruit = new List<string>
            {
                "Pear",
                "Lemon",
                "Peach"
            };

        public IEnumerable<string> Index()
        {
            return _fruit;
        }

        public IActionResult View(int id)
        {
            if (id >= 0 && id < _fruit.Count)
            {
                return Ok(_fruit[id]);
            }

            return NotFound();
        }
    }
}