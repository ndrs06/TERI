using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
namespace server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeriController : ControllerBase
{
    private readonly ILogger<TeriController> _logger;

    public TeriController(ILogger<TeriController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "TERI")]
    public ActionResult<string> Get()
    {
        try
        {
            return Ok("Hello World!");
        }
        catch (Exception e)
        {
            _logger.LogError($"{e.Message}");
            return BadRequest("sad :(");
        }
    }
}