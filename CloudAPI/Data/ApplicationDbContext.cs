using CloudAPI.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CloudAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeComment> RecipeComment { get; set; }
        public DbSet<RecipeLike> RecipeLike { get; set; }
        public DbSet<RecipeRating> RecipeRating { get; set; }
    }
}
