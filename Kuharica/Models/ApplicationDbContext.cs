using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Kuharica.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Meal> Meals { get; set; }
    
        public ApplicationDbContext()
            : base("KuharicaContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}