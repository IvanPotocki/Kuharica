using AutoMapper;
using Kuharica.Dtos;
using Kuharica.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Kuharica.Controllers.API
{
    public class RecipesController : ApiController
    {
        private ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/recipes
        public IHttpActionResult GetRecipes()
        {
            var recipes = _context.Recipes
                .Include(r => r.Meal)
                .Include(r => r.Chef)
                .ToList()
                .Select(Mapper.Map<Recipe, RecipeDto>);     

            return Ok(recipes);

        }

        // GET /api/recipes/id
        public IHttpActionResult GetRecipe(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            return Ok(Mapper.Map<Recipe, RecipeDto>(recipe));
        }

        // DELETE /api/recipes/id
        [HttpDelete]
        public IHttpActionResult DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            _context.Recipes.Remove(recipe);
            _context.SaveChanges();

            return Ok();
        }

    }
}
