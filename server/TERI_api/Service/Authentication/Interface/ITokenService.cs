using Microsoft.AspNetCore.Identity;

namespace TERI_api.Service.Authentication;

public interface ITokenService
{
    public string CreateToken(IdentityUser user, string role); 
}