using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TERI_api.Model.Enum;

namespace TERI_api.Model.DataModel;

public class Food
{
    [Key]
    public int Id { get; init; }
    public string Name { get; set; }
    public int Portion { get; set; } = 0;
    public ICollection<MealType> MealTypes { get; set; }
    public DurabilityType DurabilityType { get; set; }
    public Recipe Recipe { get; set; }
    
    [ForeignKey("FoodSlot")]
    public int FoodSlotId { get; set; }
}