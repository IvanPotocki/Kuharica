using System;
using System.ComponentModel.DataAnnotations;

namespace Kuharica.Models
{
    public class Recipe
    {
        public byte Id { get; set; }

        public DateTime Time { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        [Required]
        public ApplicationUser Chef { get; set; }

        [Required]
        public Meal Meal { get; set; }
    }
}