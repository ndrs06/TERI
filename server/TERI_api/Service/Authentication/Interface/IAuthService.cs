using TERI_api.Model.Authentication;

namespace TERI_api.Service.Authentication;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(string email, string username, string password);
}