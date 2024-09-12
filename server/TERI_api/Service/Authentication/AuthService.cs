using Microsoft.AspNetCore.Identity;
using TERI_api.Model.Authentication;
using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Serv;

namespace TERI_api.Service.Authentication;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<IdentityUser> userManager, IUserService userService, ITokenService tokenService)
    {
        _userManager = userManager;
        _userService = userService;
        _tokenService = tokenService;
    }
    
    public async Task<AuthResult> RegisterAsync(string email, string username, string password, string role)
    {
        var identityUser = new IdentityUser { UserName = username, Email = email };
        var result = await _userManager.CreateAsync(identityUser, password);

        if (!result.Succeeded)
        {
            return FailedRegistration(result, email, username);
        }
        
        await _userManager.AddToRoleAsync(identityUser, role);

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

    public async Task<AuthResult> LoginAsync(string email, string password)
    {
        var managedUser = await _userManager.FindByEmailAsync(email);
        
        if (managedUser == null)
        {
            return InvalidEmail(email);
        }
        
        var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, password);
        
        if (!isPasswordValid)
        {
            return InvalidPassword(email, managedUser.UserName);
        }
        
        var roles = await _userManager.GetRolesAsync(managedUser);
        var accessToken = _tokenService.CreateToken(managedUser, roles[0]);

        return new AuthResult(true, managedUser.Email, managedUser.UserName, accessToken);
    }
    
    private static AuthResult InvalidEmail(string email)
    {
        var result = new AuthResult(false, email, "", "");
        result.ErrorMessages.Add("Bad credentials", "Invalid email");
        return result;
    }

    private static AuthResult InvalidPassword(string email, string userName)
    {
        var result = new AuthResult(false, email, userName, "");
        result.ErrorMessages.Add("Bad credentials", "Invalid password");
        return result;
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
