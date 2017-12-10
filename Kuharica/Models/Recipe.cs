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

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAdded { get; set; }


        public ApplicationUser Chef { get; set; }

        public Meal Meal { get; set; }

        //Recipe specifics
        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime? Time { get; set; }

        public string Description { get; set; }

        public string Ingredient { get; set; }

        public string Serving { get; set; }

        public string PreparationInstruction { get; set; }



        public void Modify(
            DateTime time,
            string name,
            byte meal,
            string description,
            string ingredient,
            string serving,
            string preparationInstruction)
        {
            Time = time;
            Name = name;
            MealId = meal;
            Description = description;
            Ingredient = ingredient;
            Serving = serving;
            PreparationInstruction = preparationInstruction;
        }
    }
}