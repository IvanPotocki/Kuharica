using Kuharica.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace Kuharica.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var recipes = _context.Recipes
                .Include(r => r.Chef)
                .Include(r => r.Meal);
                
            return View(recipes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}