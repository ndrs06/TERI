using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TERI_api.Model.DataModel;

public class User
{
    [Key]
    public int Id { get; init; }
    public DateTime CreatedOn { get; set; }
    public string Name { get; set; }
    
    public Inventory Inventory { get; set; }
    
    public ICollection<Meal> Meals { get; set; }
    
    public ICollection<Recipe> RecipeCollection { get; set; }
    public ICollection<Recipe> FavoriteRecipes { get; set; }
    
    [ForeignKey(nameof(IdentityUser))]
    public string IdentityEmail { get; set; }
    public IdentityUser IdentityUser { get; set; }
}