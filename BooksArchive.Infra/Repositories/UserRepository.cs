using BooksArchive.Api.Infra.Database;
using BooksArchive.Domain.Models;
using BooksArchive.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace BooksArchive.Infra.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BooksArchiveDbContext _dbContext;
    public UserRepository(
        BooksArchiveDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, string name, string password)
    {
        var user = await GetByIdAsync(id);
        if (user == null)
            return false;

        user.Name = name;
        user.Password = password;
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Delete(Guid id)
    {
        var user = GetByIdAsync(id);
        if (user == null)
            return false;

        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        return user;
    }
    
    public User? GetByUsername(string username)
    {
        var user = _dbContext.Users.Where(p => p.Name == username).FirstOrDefault();
        return user;
    }

    public User? GetByEmail(string email)
    {
        var user = _dbContext.Users.Where(p => p.Email == email).FirstOrDefault();
        return user;
    }
}
