using TERI_api.Data;
using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public class InventoryRepository : IInventoryRepository
{
    private TERI_Context _dbContext;

    public InventoryRepository(TERI_Context dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Inventory> GetAll()
    {
        throw new NotImplementedException();
    }

    public Inventory? GetByUserId(int userId)
    {
        return _dbContext.Inventories.FirstOrDefault(x => x.UserId == userId);
    }

    public void Add(Inventory inventory)
    {
        _dbContext.Inventories.Add(inventory);
        _dbContext.SaveChanges();
    }

    public void Update(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public void Delete(Inventory inventory)
    {
        throw new NotImplementedException();
    }
}