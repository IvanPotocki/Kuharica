using Kuharica.Models;
using System.Linq;
using System.Web.Mvc;
using Kuharica.ViewModels;

namespace Kuharica.Controllers
{
    public class RecipesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }
       
        // GET: Recipes
        public ActionResult Create()
        {
            var viewModel = new RecipeFormViewModel
            {
                Meals = _context.Meals.ToList()
            };

            return View(viewModel);
        }
    }
}