namespace CamillaRecipesData.Models.Requests;

public class AddRecipeRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    public TimeSpan PreparationTime { get; set; }
    public TimeSpan CookTime { get; set; }
    public List<Category> Category { get; set; }
    public string Author { get; set; }
    public Photo RecipeImage { get; set; }
    public Video RecipeVideo { get; set; }
}