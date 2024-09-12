using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Repo;

namespace TERI_api.Service.Interface.Serv;

public interface IUserService
{
    User? GetByEmail(string email);
    void Add(User user);
}