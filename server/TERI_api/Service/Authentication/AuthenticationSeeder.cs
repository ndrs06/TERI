using Microsoft.AspNetCore.Identity;

namespace TERI_api.Service.Authentication;

public class AuthenticationSeeder
{
    private RoleManager<IdentityRole> _roleManager;
    private UserManager<IdentityUser> _userManager;
    private readonly IConfiguration _configuration;

    public AuthenticationSeeder(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _configuration = configuration;
    }
    
    public void AddRoles()
    {
        var tAdmin = CreateAdminRole(_roleManager);
        tAdmin.Wait();

        var tUser = CreateUserRole(_roleManager);
        tUser.Wait();
    }
    
    public void AddAdmin()
    {
        var tAdmin = CreateAdminIfNotExists();
        tAdmin.Wait();
    }
    
    private async Task CreateAdminRole(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync( new IdentityRole(_configuration.GetSection("JwtSettings").GetSection("Roles")["Admin"]));
    }

    async Task CreateUserRole(RoleManager<IdentityRole> roleManager)
    {
        await roleManager.CreateAsync(new IdentityRole(_configuration.GetSection("JwtSettings").GetSection("Roles")["User"]));
    }
    
    private async Task CreateAdminIfNotExists()
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var adminInDb = await _userManager.FindByEmailAsync(jwtSettings["AdminEmail"]);
        
        if (adminInDb == null)
        {
            var admin = new IdentityUser { UserName = jwtSettings["AdminUserName"], Email = jwtSettings["AdminEmail"] };
            var adminCreated = await _userManager.CreateAsync(admin, jwtSettings["AdminPassword"]);

            if (adminCreated.Succeeded)
            {
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}