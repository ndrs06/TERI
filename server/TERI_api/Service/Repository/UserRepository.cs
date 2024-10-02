using TERI_api.Data;
using TERI_api.Model.DataModel;

namespace TERI_api.Service.Repository;

public class UserRepository : IUserRepository
{
    private TERI_Context _dbContext;

    public UserRepository(TERI_Context dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return _dbContext.Users.ToList();
    }

    public async Task<User?> GetByIdAsync(int userId)
    {
        return _dbContext.Users.FirstOrDefault(user => user.Id == userId);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return _dbContext.Users.FirstOrDefault(user => user.IdentityEmail == email);
    }

    public async Task AddAsync(User user)
    {
        _dbContext.Add(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}