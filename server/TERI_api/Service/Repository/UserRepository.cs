using TERI_api.Data;
using TERI_api.Model.DataModel;
using TERI_api.Service.Interface.Repo;

namespace TERI_api.Service.Repository;

public class UserRepository : IUserRepository
{
    private TERI_Context _dbContext;

    public UserRepository(TERI_Context dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<User> GetAll()
    {
        return _dbContext.Users.ToList();
    }

    public User? GetById(int userId)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Id == userId);
    }

    public User? GetByEmail(string email)
    {
        return _dbContext.Users.FirstOrDefault(user => user.IdentityEmail == email);
    }

    public void Add(User user)
    {
        _dbContext.Add(user);
        _dbContext.SaveChanges();
    }

    public void Update(User user)
    {
        _dbContext.Update(user);
        _dbContext.SaveChanges();
    }

    public void Delete(User user)
    {
        _dbContext.Remove(user);
        _dbContext.SaveChanges();
    }
}