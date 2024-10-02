using TERI_api.Model.DataModel;

namespace TERI_api.Service;

public interface IRecipeService
{
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task AddAsync(Recipe recipe);
}