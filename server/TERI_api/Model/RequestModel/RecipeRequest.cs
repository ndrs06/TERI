using TERI_api.Model.DataModel;

namespace TERI_api.Model.RequestModel;

public class RecipeRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int RecipeCategoryId { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
}