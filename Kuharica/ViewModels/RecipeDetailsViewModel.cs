using Kuharica.Models;

namespace Kuharica.ViewModels
{
    public class RecipeDetailsViewModel
    {
        public Recipe Recipe { get; set; }
        public string FolloweeId { get; set; }
        public bool IsFollowing { get; set; }
    }
}