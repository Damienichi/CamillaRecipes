using CamillaRecipesData.Models;
using CamillaRecipesData.Models.Requests;

namespace CamillaRecipes.Interfaces;

public interface IRecipeService
{
    Task<List<Recipe>> GetRecipesAsync();
    Task<Recipe> GetRecipeAsync(int id);
    Task AddRecipeAsync(AddRecipeRequest recipe);
    Task UpdateRecipeAsync(Recipe recipe);
    Task DeleteRecipeAsync(int id);
}