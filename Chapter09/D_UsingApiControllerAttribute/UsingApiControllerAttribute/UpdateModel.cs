using System.ComponentModel.DataAnnotations;

namespace UsingApiControllerAttribute
{
    public class UpdateModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
