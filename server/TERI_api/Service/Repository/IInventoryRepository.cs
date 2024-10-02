using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public interface IInventoryRepository
{
    Task<IEnumerable<Inventory>> GetAllAsync();
    Task<Inventory?> GetByUserIdAsync(int userId);
    Task AddAsync(Inventory inventory);
    Task UpdateAsync(Inventory inventory);
    Task DeleteAsync(Inventory inventory);
}