using Kuharica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kuharica.ViewModels
{
    public class RecipeFormViewModel
    {
        [Display(Name = "Vrijeme pripreme")]
        public DateTime? Time { get; set; }

        [Display(Name = "Naziv Recepta")]
        public string Name { get; set; }

        // For dropdown numeric values
        [Display(Name = "Vrsta jela" )]
        public byte Meal { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
    }
}