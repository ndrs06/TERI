using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TERI_api.Model.DataModel;

public class InventoryFoodSlot
{
    [Key]
    public int Id { get; init; }
    public string Name { get; set; }
    public ICollection<Food> Foods { get; set; }
    
    [ForeignKey("Inventory")]
    public int InventoryId { get; init; }
}