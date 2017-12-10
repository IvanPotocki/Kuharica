using System;
using System.ComponentModel.DataAnnotations;

namespace Kuharica.Dtos
{
    public class RecipeDto
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

        public ApplicationUserDto Chef { get; set; }

        public MealDto Meal { get; set; }

        public DateTime DateAdded { get; set; }

    }
}