using CamillaRecipes.Interfaces;
using CamillaRecipesData.Models;
using CamillaRecipesData.Models.Requests;
using CamillaRecipesData.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CamillaRecipes.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;
    private readonly ILogger<RecipesController> _logger;

    public RecipesController(IRecipeService recipeService, ILogger<RecipesController> logger)
    {
        _recipeService = recipeService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetRecipes()
    {
        var recipes = await _recipeService.GetRecipesAsync();
        return Ok(recipes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(int id)
    {
        var recipe = await _recipeService.GetRecipeAsync(id);
        return Ok(recipe);
    }

    [HttpPost]
    public async Task<IActionResult> AddRecipe(AddRecipeRequest recipe)
    {
        await _recipeService.AddRecipeAsync(recipe);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRecipe(Recipe recipe)
    {
        await _recipeService.UpdateRecipeAsync(recipe);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRecipe(int id)
    {
        await _recipeService.DeleteRecipeAsync(id);
        return Ok();
    }    
}