using TERI_api.Data;
using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public class RecipeRepository : IRecipeRepository
{
    private TERI_Context _dbContext;

    public RecipeRepository(TERI_Context dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Recipe>> GetAllAsync()
    {
        return _dbContext.Recipes.ToList();
    }

    public async Task AddAsync(Recipe recipe)
    {
        _dbContext.Add(recipe);
        await _dbContext.SaveChangesAsync();
    }
}