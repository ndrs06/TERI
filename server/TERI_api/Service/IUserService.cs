using TERI_api.Model.DataModel;

namespace TERI_api.Service;

public interface IUserService
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(string email, string username);
}