using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public interface IUserRepository
{
    IEnumerable<User> GetAll();
    User? GetById(int userId);
    User? GetByEmail(string email);
    void Add(User user);
    void Update(User user);
    void Delete(User user);
}