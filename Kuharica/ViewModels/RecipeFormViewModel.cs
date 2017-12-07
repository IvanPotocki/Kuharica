using GigHub.ViewModels;
using Kuharica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kuharica.ViewModels
{
    public class RecipeFormViewModel
    {
        [Display(Name = "Naziv Recepta")]
        [Required(ErrorMessage = "Upiši naziv recepta")]
        public string Name { get; set; }

        // For dropdown numeric values
        [Display(Name = "Vrsta jela")]
        [Required(ErrorMessage = "Odaberi vrstu jela")]
        public byte Meal { get; set; }

        [Display(Name = "Vrijeme pripreme")]
        [Required(ErrorMessage = "Unesi vrijeme")]
        [ValidTime(ErrorMessage = "Unesi ispravno vrijeme")]
        public string Time { get; set; }

        public DateTime GetDateTime()
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            return DateTime.Parse(string.Format("{0} {1}", date, Time));
        }

        public IEnumerable<Meal> Meals { get; set; }

        public Recipe Recipe { get; set; }
    }
}
