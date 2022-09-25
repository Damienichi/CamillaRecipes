namespace CamillaRecipesData.Models;

public class Recipe
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    public string Notes { get; set; }
    public TimeSpan PreparationTime { get; set; }
    public TimeSpan CookTime { get; set; }
    public TimeSpan TotalTime { get; set; }
    public List<Category> Category { get; set; }
    public DateTime DateAdded { get; set; }
    public DateTime DateModified { get; set; }
    public string Author { get; set; }
    public Photo RecipeImage { get; set; }
    public Video RecipeVideo { get; set; }

}