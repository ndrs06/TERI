using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERI_api.Model.DataModel;

public class Inventory
{
    [Key]
    public int Id { get; init; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    
    public ICollection<InventoryIngredientSlot> IngredientSlots { get; set; }
    public ICollection<InventoryFoodSlot> FoodSlots { get; set; }
}