using CloudAPI.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CloudAPI.ApplicationCore.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>, IAsyncRepository<Recipe>
    {
        List<RecipeRating> GetRating(int recipeId);
    }
}
