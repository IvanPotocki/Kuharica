using Kuharica.Models;
using Kuharica.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
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
                Meals = _context.Meals.ToList(),
                Heading = "Dodaj recept"
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
                DateAdded = DateTime.Now,
                Name = viewModel.Name,
                Time = viewModel.GetDateTime(),
                MealId = viewModel.Meal,
                Description = viewModel.Description,
                Ingredient = viewModel.Ingredient,
                Serving = viewModel.Serving,
                PreparationInstruction = viewModel.PreparationInstruction
            };

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("List", "Recipes");
        }

        public ActionResult Details(int id)
        {
            var recipe = _context.Recipes
                .Include(r => r.Meal)
                .Include(r => r.Chef)
                .SingleOrDefault(c => c.Id == id);

            if (recipe == null)
                return HttpNotFound();

            return View(recipe);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var userId = User.Identity.GetUserId();
            var recipe = _context.Recipes.Single(r => r.Id == id && r.ChefId == userId);

            var viewModel = new RecipeFormViewModel
            {
                Meals = _context.Meals.ToList(),
                Id = recipe.Id,
                Name = recipe.Name,
                Time = recipe.DateAdded.ToString("HH:mm"),
                Meal = recipe.MealId,
                Description = recipe.Description,
                Ingredient = recipe.Ingredient,
                Serving = recipe.Serving,
                PreparationInstruction = recipe.PreparationInstruction,
                Heading = "Uredi Recept"
            };

            return View("RecipeForm", viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(RecipeFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Meals = _context.Meals.ToList();
                return View("RecipeForm", viewModel);
            }

            var userId = User.Identity.GetUserId();
            var recipe = _context.Recipes
                .Single(r => r.Id == viewModel.Id && r.ChefId == userId);

            recipe.Modify(viewModel.GetDateTime(), viewModel.Name, viewModel.Meal, viewModel.Description, viewModel.Ingredient, viewModel.Serving, viewModel.PreparationInstruction);

            _context.SaveChanges();

            return RedirectToAction("List", "Recipes");
        }

        public ViewResult List()
        {
            return View();
        }
    }
}