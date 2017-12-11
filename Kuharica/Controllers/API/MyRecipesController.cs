using AutoMapper;
using Kuharica.Dtos;
using Kuharica.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace Kuharica.Controllers.API
{
    public class MyRecipesController : ApiController
    {
        private ApplicationDbContext _context;

        public MyRecipesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMineRecipes()
        {
            var userId = User.Identity.GetUserId();
            var recipes = _context.Recipes
                .Where(r => r.ChefId == userId)
                .Include(r => r.Meal)
                .ToList()
                .Select(Mapper.Map<Recipe, MyRecipeDto>);

            return Ok(recipes);
        }

        // DELETE /api/recipes/id
        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(r => r.Id == id);

            if (recipe == null)
                return NotFound();

            _context.Recipes.Remove(recipe);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        [Authorize]
        public IHttpActionResult UpdateMovie(int id, MyRecipeDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipe == null)
                return NotFound();

            Mapper.Map(movieDto, recipe);

            _context.SaveChanges();

            return Ok();
        }
    }
}
