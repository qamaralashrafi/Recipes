using Microsoft.EntityFrameworkCore;

namespace RecipeBook.Models.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {}
        public DbSet<AllRecipes> allrecipes { get; set; }
    }
}
