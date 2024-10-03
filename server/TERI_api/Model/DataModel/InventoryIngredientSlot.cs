using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERI_api.Model.DataModel;

public class InventoryIngredientSlot
{
    [Key]
    public int Id { get; init; }
    public string Name { get; set; }
    public ICollection<Ingredient> Ingredients { get; set; }
    
    [ForeignKey("Inventory")]
    public int InventoryId { get; init; }
}