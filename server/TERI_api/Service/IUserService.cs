using TERI_api.Model.DataModel;

namespace TERI_api.Service;

public interface IUserService
{
    User? GetByEmail(string email);
    void AddNewUser(string email, string username);
}