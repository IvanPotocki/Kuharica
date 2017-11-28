using Kuharica.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kuharica.ViewModels
{
    public class RecipeFormViewModel
    {
        public byte Id { get; set; }

        [Display(Name = "Vrijeme pripreme")]
        public string Time { get; set; }

        [Display(Name = "Ime i prezime")]
        public string Name { get; set; }

        // For dropdown numeric values
        [Display(Name = "Vrsta jela" )]
        public int Meal { get; set; }
        public IEnumerable<Meal> Meals { get; set; }
    }
}