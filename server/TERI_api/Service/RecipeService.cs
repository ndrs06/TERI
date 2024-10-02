using TERI_api.Model.DataModel;
using TERI_api.Service.Repository;

namespace TERI_api.Service;

public class RecipeService : IRecipeService
{
    private IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        var recipes = await _recipeRepository.GetAllAsync();
        return recipes.ToList();
    }

    public Task AddAsync(Recipe recipe)
    {
        throw new NotImplementedException();
    }
}