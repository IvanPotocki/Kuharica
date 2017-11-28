using Kuharica.Models;
using Kuharica.ViewModels;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Mvc;

namespace Kuharica.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        // DropDownList
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new RecipeFormViewModel
            {
                Meals = _context.Meals.ToList()
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(RecipeFormViewModel viewModel)
        {
            var recipe = new Recipe
            {
                ChefId = User.Identity.GetUserId(),
                Name = viewModel.Name,
                Time = viewModel.Time,
                MealId = viewModel.Meal
            };

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}