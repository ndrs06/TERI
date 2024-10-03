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

    public IEnumerable<Recipe> GetAll()
    {
        return _recipeRepository.GetAll().ToList();
    }

    public void Add(Recipe recipe)
    {
        throw new NotImplementedException();
    }
}