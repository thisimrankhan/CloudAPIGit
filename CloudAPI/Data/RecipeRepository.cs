using CloudAPI.ApplicationCore.Interfaces;
using CloudAPI.Data;
using CloudAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudAPI.Infrastructure.Data
{
    public class RecipeRepository : EfRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            
        }
        
        public List<RecipeRating> GetRating(int recipeId)
        {
            var recipeRating = _dbContext.RecipeRating.Where(r => r.RecipeId == recipeId).ToList();
            return recipeRating;
        }
    }
}
