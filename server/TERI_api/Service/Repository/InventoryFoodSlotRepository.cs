using TERI_api.Data;
using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public class InventoryFoodSlotRepository : IInventoryFoodSlotRepository
{
    private TERI_Context _dbContext;

    public InventoryFoodSlotRepository(TERI_Context dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<InventoryFoodSlot> GetAll()
    {
        return _dbContext.InventoryFoodSlot.ToList();
    }

    public InventoryFoodSlot? GetById(int inventoryFoodSlotSlotId)
    {
        return _dbContext.InventoryFoodSlot.FirstOrDefault(x => x.Id == inventoryFoodSlotSlotId);
    }

    public void Add(InventoryFoodSlot inventoryFoodSlotSlot)
    {
        _dbContext.Add(inventoryFoodSlotSlot);
        _dbContext.SaveChanges();
    }

    public void Update(InventoryFoodSlot inventoryFoodSlotSlot)
    {
        _dbContext.Update(inventoryFoodSlotSlot);
        _dbContext.SaveChanges();
    }

    public void Delete(InventoryFoodSlot inventoryFoodSlotSlot)
    {
        _dbContext.Remove(inventoryFoodSlotSlot);
        _dbContext.SaveChanges();
    }
}