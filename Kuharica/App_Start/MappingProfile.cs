using AutoMapper;
using Kuharica.Dtos;
using Kuharica.Models;

namespace Kuharica.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
            CreateMap<Recipe, RecipeDto>();
            CreateMap<Recipe, MyRecipeDto>();
            CreateMap<Meal, MealDto>();
            CreateMap<ApplicationUser, ApplicationUserDto>();
            //CreateMap<Following, FollowingDto>();


            // Dto to Domain
            //CreateMap<RecipeDto, Recipe>();

        }
    }
}