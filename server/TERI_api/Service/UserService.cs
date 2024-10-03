using TERI_api.Model.DataModel;
using TERI_api.Service.Repository;

namespace TERI_api.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IInventoryRepository _inventoryRepository;

    public UserService(IUserRepository userRepository, IInventoryRepository inventoryRepository)
    {
        _userRepository = userRepository;
        _inventoryRepository = inventoryRepository;
    }

    public User? GetByEmail(string email)
    {
        return _userRepository.GetByEmail(email);
    }

    public void AddNewUser(string email, string username)
    {
        var newUser = new User
        {
            RegistrationDate = DateTime.Now,
            Name = username,
            RecipeCollection = new List<Recipe>(),
            FavoriteRecipes = new List<Recipe>(),
            IdentityEmail = email
        };
        
        _userRepository.Add(newUser);

        AddInventoryToNewUser(newUser.Id);
        
    }

    private void AddInventoryToNewUser(int userId)
    {
        var inventory = new Inventory
        {
            UserId = userId,
            IngredientSlots = new List<InventoryIngredientSlot>(),
            FoodSlots = new List<InventoryFoodSlot>()
        };
        
        var ingredientSlot = new InventoryIngredientSlot
        {
            Name = "Ingredient Slot #1",
            Ingredients = new List<Ingredient>()
        };

        var foodSlot = new InventoryFoodSlot
        {
            Name = "Food Slot #2",
            Foods = new List<Food>()
        };
                
        inventory.IngredientSlots.Add(ingredientSlot);
        inventory.FoodSlots.Add(foodSlot);
        
        _inventoryRepository.Add(inventory);
    }
}