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
        

}
