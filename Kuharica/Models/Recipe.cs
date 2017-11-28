using System;
using System.ComponentModel.DataAnnotations;

namespace Kuharica.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        [Required]
        public string ChefId { get; set; }

        [Required]
        public byte MealId { get; set; }

        public DateTime? Time { get; set; }

        public ApplicationUser Chef { get; set; }

        public Meal Meal { get; set; }  
    }
}