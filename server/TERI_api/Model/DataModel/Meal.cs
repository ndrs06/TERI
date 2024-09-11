using System.ComponentModel.DataAnnotations;
using TERI_api.Model.Enum;

namespace TERI_api.Model.DataModel;

public class Meal
{
    [Key]
    public int Id { get; set; }
    public MealType MealType { get; set; }
    public ICollection<Food> Foods { get; set; }
}