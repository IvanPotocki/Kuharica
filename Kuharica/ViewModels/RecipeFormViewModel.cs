using GigHub.ViewModels;
using Kuharica.Controllers;
using Kuharica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Kuharica.ViewModels
{
    public class RecipeFormViewModel
    {
        [Display(Name = "Naziv recepta")]
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

        [Display(Name = "Opis recepta")]
        public string Description { get; set; }

        [Display(Name = "Sastojci")]
        public string Ingredient { get; set; }

        [Display(Name = "Broj porcija")]
        public string Serving { get; set; }

        [Display(Name = "Priprema")]
        public string PreparationInstruction { get; set; }

        public IEnumerable<Meal> Meals { get; set; }

        //public Recipe Recipe { get; set; }
        
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        public string Heading { get; set; }

        // !!!
        public DateTime GetDateTime()
        {
            var date = DateTime.Now.ToString("dd/MM/yyyy");
            return DateTime.Parse(string.Format("{0} {1}", date, Time));
        }

        public string Action
        {
            get
            {
                Expression<Func<RecipesController, ActionResult>> update =
                    (c => c.Update(this));

                Expression<Func<RecipesController, ActionResult>> create =
                    (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}
