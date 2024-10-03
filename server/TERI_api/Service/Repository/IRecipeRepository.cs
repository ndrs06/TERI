using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public interface IRecipeRepository
{
    IEnumerable<Recipe> GetAll();
    void Add(Recipe recipe);
}