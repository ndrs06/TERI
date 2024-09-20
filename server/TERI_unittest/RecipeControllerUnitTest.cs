using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using TERI_api.Controllers;
using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Serv;

namespace TERI_unit_test;

public class RecipeControllerUnitTest
{
    private Mock<ILogger<RecipeController>> _loggerMock;
    private Mock<IRecipeService> _recipeServiceMock;
    private RecipeController _recipeControllerUnit;

    [SetUp]
    public void Setup()
    {
        _loggerMock = new Mock<ILogger<RecipeController>>();
        _recipeServiceMock = new Mock<IRecipeService>();
        _recipeControllerUnit = new RecipeController(_loggerMock.Object, _recipeServiceMock.Object);
    }

    [Test]
    public void GetRecipeTest_ReturnOk_ListAllRecipes()
    {
        // Arrange
        var recipes = new List<Recipe>();
        _recipeServiceMock.Setup(s => s.GetAll()).Returns(recipes);
        
        // Act
        var res = _recipeControllerUnit.Get();
        
        // Assert
        var okResult = res.Result as OkObjectResult;
        Assert.IsNotNull(okResult);
        Assert.IsInstanceOf<OkObjectResult>(okResult);
        Assert.IsInstanceOf<List<Recipe>>(okResult.Value);
        _recipeServiceMock.Verify(s => s.GetAll(), Times.Once);
    }
}