using TERI_api.Model.DataModel;

namespace TERI_api.Service.Interface.Serv;

public interface IRecipeService
{
    IEnumerable<Recipe> GetAll();
    void Add(Recipe recipe);
}