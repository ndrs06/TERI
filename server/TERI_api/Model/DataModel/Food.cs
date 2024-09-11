using System.ComponentModel.DataAnnotations;
using TERI_api.Model.Enum;

namespace TERI_api.Model.DataModel;

public class Food
{
    [Key]
    public int Id { get; init; }
    public string Name { get; set; }
    public int Portion { get; set; }
    public ICollection<MealType> MealTypes { get; set; }
    public DurabilityType DurabilityType { get; set; }
    public Recipe Recipe { get; set; }
}