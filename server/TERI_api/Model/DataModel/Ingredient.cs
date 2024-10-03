using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TERI_api.Model.Enum;

namespace TERI_api.Model.DataModel;

public class Ingredient
{
    [Key]
    public int Id { get; init; }
    public string Name { get; set; }
    public decimal Quantity { get; set; } = 0;
    public UnitType Unit { get; set; }
    
    [ForeignKey("IngredientCategory")]
    public int IngredientCategoryId { get; set; }

    public decimal AvgPrice { get; set; } = 0;
    public string ImageUrl { get; set; }
    
    [ForeignKey("IngredientSlot")]
    public int IngredientSlotId { get; set; }
    
}