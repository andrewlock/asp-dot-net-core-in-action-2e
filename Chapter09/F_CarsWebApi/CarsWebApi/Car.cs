using System.ComponentModel.DataAnnotations;

namespace CarsWebApi
{
    public class Car
    {
        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
    }
}
