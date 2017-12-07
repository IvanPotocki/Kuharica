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
            CreateMap<Meal, MealDto>();
            CreateMap<ApplicationUser, ApplicationUserDto>();


            // Dto to Domain
            CreateMap<RecipeDto, Recipe>();

        }
    }
}