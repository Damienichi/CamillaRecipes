using CamillaRecipes.Contexts;
using CamillaRecipes.Interfaces;
using CamillaRecipes.Settings;
using CamillaRecipesData.Models;
using CamillaRecipesData.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CamillaRecipes.Services;

public class RecipesService: IRecipeService
{
    private readonly RecipesContext _context;
    private readonly ILogger<RecipesService> _logger;

    public RecipesService(IOptions<SqlSettings> settings, ILogger<RecipesService> logger)
    {
        _context = new RecipesContext(settings);
        _logger = logger;
    }

    public Task<List<Recipe>> GetRecipesAsync()
    {
        return _context.Recipes.ToListAsync();
    }

    public async Task<Recipe> GetRecipeAsync(int id)
    {
        var recipe = _context.Recipes.FirstOrDefault(x=> x.Id == id);
        if (recipe == null)
        {
            _logger.LogError($"Recipe with id {id} not found");
            return new Recipe();
        }

        return recipe;
    }

    public Task AddRecipeAsync(AddRecipeRequest recipe)
    {
        var newRecipe = new Recipe
        {
            Name = recipe.Name,
            Description = recipe.Description,
            Ingredients = recipe.Ingredients,
            Instructions = recipe.Instructions,
            PreparationTime = recipe.PreparationTime,
            CookTime = recipe.CookTime,
            TotalTime = recipe.PreparationTime + recipe.CookTime,
            DateAdded = DateTime.Now,
            DateModified = DateTime.Now,
            Author = recipe.Author,
            Category = recipe.Category,
            RecipeImage = recipe.RecipeImage,
            RecipeVideo = recipe.RecipeVideo,
        };
        _context.Recipes.Add(newRecipe);
        return _context.SaveChangesAsync();
    }

    public Task UpdateRecipeAsync(Recipe recipe)
    {
        recipe.DateModified = DateTime.Now;
        _context.Entry(recipe).State = EntityState.Modified;
        return _context.SaveChangesAsync();
    }

    public Task DeleteRecipeAsync(int id)
    {
        var recipe = _context.Recipes.Find(id);
        if (recipe != null) _context.Recipes.Remove(recipe);
        return _context.SaveChangesAsync();
    }
}