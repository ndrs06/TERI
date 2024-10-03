using TERI_api.Model.DataModel;
using TERI_api.Service.Repository;

namespace TERI_api.Service;

public class InventoryIngredientSlotService : IInventoryIngredientSlotService
{
    private readonly IInventoryIngredientSlotRepository _inventoryIngredientSlotRepository;

    public InventoryIngredientSlotService(IInventoryIngredientSlotRepository inventoryIngredientSlotRepository)
    {
        _inventoryIngredientSlotRepository = inventoryIngredientSlotRepository;
    }

    public void AddNewIngredientSlotToInventory(int inventoryId, string name)
    {
        var ingredientSlot = new InventoryIngredientSlot
        {
            Name = name,
            Ingredients = new List<Ingredient>(),
            InventoryId = inventoryId
        };
        
        _inventoryIngredientSlotRepository.Add(ingredientSlot);
    }
}