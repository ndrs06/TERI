using TERI_api.Model.DataModel;
using TERI_api.Service.Repository;

namespace TERI_api.Service;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;

    public InventoryService(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }


    public void AddInventoryToNewUser(int userId)
    {
        var inventory = new Inventory
        {
            UserId = userId,
            IngredientSlots = new List<InventoryIngredientSlot>(),
            FoodSlots = new List<InventoryFoodSlot>()
        };
        
        var ingredientSlot = new InventoryIngredientSlot
        {
            Name = "Ingredient Slot #1",
            Ingredients = new List<Ingredient>()
        };

        var foodSlot = new InventoryFoodSlot
        {
            Name = "Food Slot #2",
            Foods = new List<Food>()
        };
                
        inventory.IngredientSlots.Add(ingredientSlot);
        inventory.FoodSlots.Add(foodSlot);
        
        _inventoryRepository.Add(inventory);
    }
}