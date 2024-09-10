using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERI_api.Model.DataModel;

public class Recipe
{
    [Key]
    public int Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey("Category")]
    public int RecipeCategoryId { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
    
    public string ImageUrl { get; set; }
}