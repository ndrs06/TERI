using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public interface IIngredientRepository
{
    IEnumerable<Ingredient> GetAll();
    Ingredient? GetById(int ingredientId);
    void Add(Ingredient ingredient);
    void Update(Ingredient ingredient);
    void Delete(Ingredient ingredient);
}