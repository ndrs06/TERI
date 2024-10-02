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

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        return user;
    }

    public async Task AddAsync(string email, string username)
    {
        var newUser = new User
        {
            RegistrationDate = DateTime.Now,
            Name = username,
            Inventory = new Inventory(),
            RecipeCollection = new List<Recipe>(),
            FavoriteRecipes = new List<Recipe>(),
            IdentityEmail = email
        };
        
        await _userRepository.AddAsync(newUser);
        
        var user = await _userRepository.GetByEmailAsync(email);

        if (user != null)
        {
            var inventory = await _inventoryRepository.GetByUserIdAsync(user.Id);
            
            inventory.IngredientSlots = new List<InventoryIngredientSlot>();
            inventory.FoodSlots = new List<InventoryFoodSlot>();

            if (inventory != null)
            {
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
            }
        }
    }
}