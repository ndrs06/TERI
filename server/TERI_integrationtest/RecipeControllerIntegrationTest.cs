using System.Net;
using Microsoft.AspNetCore.Mvc;
using TERI_api.Model.DataModel;
using Xunit;

namespace TERI_integrationtest;

[Collection("IntegrationTest")]

public class RecipeControllerIntegrationTest
{
    private readonly HttpClient _client;
    private readonly TERI_WebAppFactory _factory;

    public RecipeControllerIntegrationTest()
    {
        _factory = new TERI_WebAppFactory();
        _client = _factory.CreateClient();
    }

    [Fact]
    public async Task GetAllRecipes()
    {
        // Arrange
        var requestURL = "/api/recipes";

        // Act
        var response = await _client.GetAsync(requestURL);
        
        // Assert
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        Assert.NotNull(content);
    }
}