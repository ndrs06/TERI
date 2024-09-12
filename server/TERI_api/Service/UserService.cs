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

    public void Add(User user)
    {
        _userRepository.Add(user);
    }
}