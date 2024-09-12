using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Repo;

namespace TERI_api.Service.Interface.Serv;

public interface IUserService
{
    void Add(User user);
}