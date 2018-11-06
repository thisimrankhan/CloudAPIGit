using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CloudAPI.ApplicationCore.Interfaces;
using CloudAPI.ApplicationCore.Services;
using CloudAPI.Data;
using CloudAPI.Models.Entities;
using CloudAPI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloudAPI.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Route("api/[controller]/[action]")]
    public class RecipeController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly ApplicationDbContext _appDbContext;
        private readonly IRecipeService _RecipeService;

        public RecipeController(UserManager<AppUser> userManager, ApplicationDbContext appDbContext, IHttpContextAccessor httpContextAccessor, IRecipeService RecipeService)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
            _RecipeService = RecipeService;
        }

        // GET api/Recipe/GetRecipe
        [HttpGet]
        public IActionResult GetRecipe(int Id)
        {
            var Recipe = _RecipeService.GetRecipeById(Id).Result;
            return new OkObjectResult(Recipe);
        }

        // GET api/Recipe/
        [HttpGet]
        public IActionResult GetRecipes()
        {
            var Recipes = _RecipeService.GetRecipes().Result;
            return new OkObjectResult(Recipes);
        }

        [HttpPost]
        public IActionResult AddRecipe([FromBody]RecipeViewModel recipe)
        {
            var response = _RecipeService.AddRecipe(recipe).Result;
            return new OkObjectResult(response);
        }

        [HttpPost]
        public IActionResult AddRecipieRating([FromBody]RecipeRating recipeRating)
        {
            var response = _RecipeService.AddRating(recipeRating).Result;
            return new OkObjectResult(response);
        }

        [HttpPost]
        public IActionResult AddRecipieLike([FromBody]RecipeLike recipeLike)
        {
            var response = _RecipeService.AddLike(recipeLike).Result;
            return new OkObjectResult(response);
        }

        [HttpGet]
        public IActionResult GetLikedRecipeById(string userId, int recipeId)
        {
            var isLiked = _RecipeService.GetLikedRecipeById(userId, recipeId);
            return new OkObjectResult(isLiked);
        }

        [HttpPost]
        public IActionResult AddRecipieComment([FromBody]RecipeComment recipeComment)
        {
            var response = _RecipeService.AddComment(recipeComment).Result;
            return new OkObjectResult(response);
        }
    }
}
