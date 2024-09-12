using TERI_api.Model.DataModel;

namespace TERI_api.Service.Interface.Repo;

public interface IRecipeRepository
{
    IEnumerable<Recipe> GetAll();
    void Add(Recipe recipe);
}