using Microsoft.AspNetCore.Mvc;
namespace TERI_api.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminController : ControllerBase
{
    private readonly ILogger<AdminController> _logger;

    public AdminController(ILogger<AdminController> logger)
    {
        _logger = logger;
    }

    [HttpPost("recipe")]
    public ActionResult<string> PostRecipe()
    {
        try
        {
            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
            return BadRequest("sad :(");
        }
    }
}