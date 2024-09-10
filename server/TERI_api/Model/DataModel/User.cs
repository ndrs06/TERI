using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERI_api.Model.DataModel;

public class User
{
    [Key]
    public int Id { get; init; }
    public DateTime CreatedOn { get; set; }
    public string Name { get; set; }
    
    public Inventory Inventory { get; set; }
    
    public ICollection<Recipe> RecipeCollection { get; set; }
    public ICollection<Recipe> FavoriteRecipes { get; set; }
}