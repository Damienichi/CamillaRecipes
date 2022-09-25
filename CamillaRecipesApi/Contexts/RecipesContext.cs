using CamillaRecipes.Settings;
using CamillaRecipesData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CamillaRecipes.Contexts;

public class RecipesContext: DbContext
{
    public DbSet<Recipe> Recipes { get; set; }

    private readonly SqlSettings _sqlSettings;

    public RecipesContext(IOptions<SqlSettings> sqlSettings)
    {
        _sqlSettings = sqlSettings.Value;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_sqlSettings.ConnectionString);
    }
}