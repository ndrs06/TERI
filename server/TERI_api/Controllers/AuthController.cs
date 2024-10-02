using Microsoft.AspNetCore.Mvc;
using TERI_api.Model.Authentication;
using TERI_api.Model.DataModel;
using TERI_api.Service;
using TERI_api.Service.Authentication;

namespace TERI_api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authenticationService;
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;

    public AuthController(IAuthService authenticationService, IUserService userService, IConfiguration configuration)
    {
        _authenticationService = authenticationService;
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("sign-up")]
    public async Task<ActionResult<RegistrationResponse>> Register([FromBody] RegistrationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var userRole = _configuration.GetSection("JwtSettings").GetSection("Roles")["User"];
        var result = await _authenticationService.RegisterAsync(request.Email, request.Username, request.Password, userRole);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        return CreatedAtAction(nameof(Register), new RegistrationResponse(result.Email, result.UserName));
    }
    
    [HttpPost("sign-in")]
    public async Task<ActionResult<User>> Login([FromBody] LoginRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _authenticationService.LoginAsync(request.Email, request.Password);

        if (!result.Success)
        {
            AddErrors(result);
            return BadRequest(ModelState);
        }

        var token = result.Token;
        
        HttpContext.Response.Cookies.Append("access_token", token, new CookieOptions{HttpOnly = true});

        return Ok(_userService.GetByEmailAsync(request.Email));
    }

    private void AddErrors(AuthResult result)
    {
        foreach (var error in result.ErrorMessages)
        {
            ModelState.AddModelError(error.Key, error.Value);
        }
    }
}