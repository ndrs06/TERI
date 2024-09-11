using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Repo;
using TERI_api.Service.Interface.Serv;

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
        return _recipeRepository.GetAll();
    }

    public void Add(Recipe recipe)
    {
        throw new NotImplementedException();
    }
}