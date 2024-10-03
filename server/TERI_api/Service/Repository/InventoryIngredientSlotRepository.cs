using TERI_api.Data;
using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public class InventoryIngredientSlotRepository : IInventoryIngredientSlotRepository
{
    private TERI_Context _dbContext;

    public InventoryIngredientSlotRepository(TERI_Context dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<InventoryIngredientSlot> GetAll()
    {
        return _dbContext.InventoryIngredientSlot.ToList();
    }

    public InventoryIngredientSlot? GetById(int inventoryIngredientSlotId)
    {
        return _dbContext.InventoryIngredientSlot.FirstOrDefault(x => x.Id == inventoryIngredientSlotId);
    }

    public void Add(InventoryIngredientSlot inventoryIngredientSlot)
    {
        _dbContext.Add(inventoryIngredientSlot);
        _dbContext.SaveChanges();
    }

    public void Update(InventoryIngredientSlot inventoryIngredientSlot)
    {
        _dbContext.Update(inventoryIngredientSlot);
        _dbContext.SaveChanges();
    }

    public void Delete(InventoryIngredientSlot inventoryIngredientSlot)
    {
        _dbContext.Remove(inventoryIngredientSlot);
        _dbContext.SaveChanges();
    }
}