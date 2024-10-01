using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Repo;
using TERI_api.Service.Interface.Serv;

namespace TERI_api.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User? GetByEmail(string email)
    {
        return _userRepository.GetByEmail(email);
    }

    public void Add(string email, string username)
    {
        var user = new User
        {
            RegistrationDate = DateTime.Now,
            Name = username,
            Inventory = new Inventory(),
            RecipeCollection = new List<Recipe>(),
            FavoriteRecipes = new List<Recipe>(),
            IdentityEmail = email
        };
        
        _userRepository.Add(user);
    }
}