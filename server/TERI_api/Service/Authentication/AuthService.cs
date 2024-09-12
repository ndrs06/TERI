using Microsoft.AspNetCore.Identity;
using TERI_api.Model.Authentication;
using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Serv;

namespace TERI_api.Service.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserService _userService;

    public AuthService(UserManager<IdentityUser> userManager, IUserService userService)
    {
        _userManager = userManager;
        _userService = userService;
    }
    
    public async Task<AuthResult> RegisterAsync(string email, string username, string password)
    {  
        var result = await _userManager.CreateAsync(new IdentityUser { UserName = username, Email = email }, password);

        if (!result.Succeeded)
        {
            return FailedRegistration(result, email, username);
        }

        var user = new User
        {
            RegistrationDate = DateTime.Now,
            Name = username,
            Inventory = new Inventory(),
            RecipeCollection = new List<Recipe>(),
            FavoriteRecipes = new List<Recipe>(),
            IdentityEmail = email
        };
        
        _userService.Add(user);
        
        return new AuthResult(true, email, username, "");
    }
    
    private static AuthResult FailedRegistration(IdentityResult result, string email, string username)
    {
        var authResult = new AuthResult(false, email, username, "");

        foreach (var error in result.Errors)
        {
            authResult.ErrorMessages.Add(error.Code, error.Description);
        }

        return authResult;
    }
}