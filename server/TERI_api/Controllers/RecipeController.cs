using Microsoft.AspNetCore.Mvc;
using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Serv;

namespace TERI_api.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipeController : ControllerBase
{
    private readonly ILogger<RecipeController> _logger;
    private readonly IRecipeService _recipeService;

    public RecipeController(ILogger<RecipeController> logger, IRecipeService recipeService)
    {
        _logger = logger;
        _recipeService = recipeService;
    }

    [HttpGet(Name = "TERI")]
    public ActionResult<IEnumerable<Recipe>> Get()
    {
        try
        {
            return Ok(_recipeService.GetAll());
        }
        catch (Exception e)
        {
            _logger.LogError(e,$"{e.Message}");
            return StatusCode(500, "Internal Server Error :(");
        }
    }
}