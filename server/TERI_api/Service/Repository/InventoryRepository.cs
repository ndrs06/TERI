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

    public Task<IEnumerable<Inventory>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<Inventory?> GetByUserIdAsync(int userId)
    {
        return _dbContext.Inventories.FirstOrDefault(x => x.UserId == userId);
    }

    public async Task AddAsync(Inventory inventory)
    {
        _dbContext.Inventories.Add(inventory);
        await _dbContext.SaveChangesAsync();
    }

    public Task UpdateAsync(Inventory inventory)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Inventory inventory)
    {
        throw new NotImplementedException();
    }
}