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
        public ActionResult New()
        {
            var viewModel = new RecipeFormViewModel
            {
                Recipe = new Recipe(),
                Meals = _context.Meals.ToList()
            };

            return View("RecipeForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Meals = _context.Meals.ToList();
                return View("RecipeForm", viewModel);
            }

            var recipe = new Recipe
            {
                ChefId = User.Identity.GetUserId(),
                Name = viewModel.Name,
                Time = viewModel.GetDateTime(),
                MealId = viewModel.Meal
            };

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("List", "Recipes");
        }

        public ViewResult List()
        {
            return View();
        }
    }
}