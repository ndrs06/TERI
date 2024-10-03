using TERI_api.Model.DataModel;

namespace TERI_api.Service;

public interface IInventoryService
{
    void AddInventoryToNewUser(int userId);
}