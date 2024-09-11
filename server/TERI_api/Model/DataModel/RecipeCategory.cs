using System.ComponentModel.DataAnnotations;
using TERI_api.Model.Enum;

namespace TERI_api.Model.DataModel;

public class RecipeCategory
{
    [Key]
    public int Id { get; init; }
    public RecipeCategoryType Name { get; set; }
}