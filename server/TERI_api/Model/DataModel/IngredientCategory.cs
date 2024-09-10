using System.ComponentModel.DataAnnotations;
using TERI_api.Model.Enum;

namespace TERI_api.Model.DataModel;

public class IngredientCategory
{
    [Key]
    public int Id { get; init; }
    public IngredientCategoryType Name { get; set; }
}