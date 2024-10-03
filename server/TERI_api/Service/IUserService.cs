using TERI_api.Model.DataModel;

namespace TERI_api.Service;

public interface IUserService
{
    Task<User?> GetByEmailAsync(string email);
    Task AddNewUserAsync(string email, string username);
}