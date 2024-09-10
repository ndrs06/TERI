using System.ComponentModel.DataAnnotations;

namespace TERI_api.Model.DataModel;

public class InventoryFoodSlot
{
    [Key]
    public int Id { get; init; }
    public string Name { get; set; }
    public ICollection<Food> Foods { get; set; }
}