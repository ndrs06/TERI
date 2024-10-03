using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public interface IInventoryRepository
{
    IEnumerable<Inventory> GetAll();
    Inventory? GetByUserId(int userId);
    void Add(Inventory inventory);
    void Update(Inventory inventory);
    void Delete(Inventory inventory);
}