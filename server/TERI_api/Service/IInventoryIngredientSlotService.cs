using TERI_api.Model.DataModel;

namespace TERI_api.Service;

public interface IInventoryIngredientSlotService
{
    void AddNewIngredientSlotToInventory(int inventoryId, string name);
}