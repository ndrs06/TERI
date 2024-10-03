using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public interface IInventoryFoodSlotRepository
{
    IEnumerable<InventoryFoodSlot> GetAll();
    InventoryFoodSlot? GetById(int inventoryFoodSlotSlotId);
    void Add(InventoryFoodSlot inventoryFoodSlotSlot);
    void Update(InventoryFoodSlot inventoryFoodSlotSlot);
    void Delete(InventoryFoodSlot inventoryFoodSlotSlot);
}