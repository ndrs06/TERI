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
    
    public IEnumerable<Recipe> GetAll()
    {
        return _dbContext.Recipes.ToList();
    }

    public void Add(Recipe recipe)
    {
        _dbContext.Add(recipe);
        _dbContext.SaveChanges();
    }
}