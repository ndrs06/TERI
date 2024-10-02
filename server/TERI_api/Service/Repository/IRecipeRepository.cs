using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetAllAsync();
    Task AddAsync(Recipe recipe);
}