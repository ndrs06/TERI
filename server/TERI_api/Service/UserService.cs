using TERI_api.Model.DataModel;
using TERI_api.Service.Repository;

namespace TERI_api.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IInventoryService _inventoryService;

    public UserService(IUserRepository userRepository, IInventoryService inventoryService)
    {
        _userRepository = userRepository;
        _inventoryService = inventoryService;
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return _userRepository.GetByEmail(email);
    }

    public async Task AddNewUserAsync(string email, string username)
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
        
        var user = await GetByEmailAsync(email);

        if (user != null)
        {
            _inventoryService.AddInventoryToNewUser(user.Id);
        }
    }
}