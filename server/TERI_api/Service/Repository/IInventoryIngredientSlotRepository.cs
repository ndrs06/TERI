using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public interface IInventoryIngredientSlotRepository
{
    IEnumerable<InventoryIngredientSlot> GetAll();
    InventoryIngredientSlot? GetById(int inventoryIngredientSlotId);
    void Add(InventoryIngredientSlot inventoryIngredientSlot);
    void Update(InventoryIngredientSlot inventoryIngredientSlot);
    void Delete(InventoryIngredientSlot inventoryIngredientSlot);
}