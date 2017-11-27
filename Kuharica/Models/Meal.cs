using System.ComponentModel.DataAnnotations;

namespace Kuharica.Models
{
    public class Meal
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Type { get; set; }
    }
}