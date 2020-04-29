using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        /// <summary>
        /// This represents the global application model that would
        /// normally be stored in a database etc
        /// </summary>
        private static List<Car> Cars = new List<Car> { };

        string _carsAsXml = "<cars><car>Nissan Micra</car><car>FordFocus</car></cars>";

        [Route("start")]
        [Route("ignition")]
        [Route("/start-car")]
        public IEnumerable<string> ListCars()
        {
            return new string[]
                { "Nissan Micra", "FordFocus" };
        }

        [HttpGet("null")]
        public IActionResult Null()
        {
            return Ok(null);
        }

        [HttpGet("content")]
        public string ListCarsAsContent()
        {
            return _carsAsXml;
        }

        [HttpGet("xml")]
        public IActionResult ListCarsAsXml()
        {
            return Content(_carsAsXml, "text/xml");
        }

        [HttpGet("json")]
        public IActionResult ListCarsAsJson()
        {
            return new JsonResult(new string[]
                { "Nissan Micra", "FordFocus" });
        }

        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Cars.Add(car);
            return Ok();
        }
    }
}