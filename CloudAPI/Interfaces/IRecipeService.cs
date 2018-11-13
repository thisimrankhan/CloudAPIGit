using CloudAPI.Models.Entities;
using CloudAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudAPI.ApplicationCore.Interfaces
{
    public interface IRecipeService
    {
        Task<List<RecipeViewModel>> GetRecipes();
        Task<RecipeViewModel> GetRecipeById(int Id);
        Task<RecipeViewModel> AddRecipe(RecipeViewModel recipeView);
        Task<RecipeRating> AddRating(RecipeRating rating);
        Task<RecipeLike> AddLike(RecipeLike like);
        Task<RecipeComment> AddComment(RecipeComment comment);
        bool GetLikedRecipeById(string userId, int recipeId);
        int GetRecipeRatingByUserId(int recipeId, string userId);
    }
}
