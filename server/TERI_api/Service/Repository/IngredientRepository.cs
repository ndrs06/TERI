using TERI_api.Data;
using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public class IngredientRepository : IIngredientRepository
{
    private TERI_Context _dbContext;

    public IngredientRepository(TERI_Context dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Ingredient> GetAll()
    {
        return _dbContext.Ingredients.ToList();
    }

    public Ingredient? GetById(int ingredientId)
    {
        return _dbContext.Ingredients.FirstOrDefault(x => x.Id == ingredientId);
    }

    public void Add(Ingredient ingredient)
    {
        _dbContext.Add(ingredient);
        _dbContext.SaveChanges();
    }

    public void Update(Ingredient ingredient)
    {
        _dbContext.Update(ingredient);
        _dbContext.SaveChanges();
    }

    public void Delete(Ingredient ingredient)
    {
        _dbContext.Remove(ingredient);
        _dbContext.SaveChanges();
    }
}