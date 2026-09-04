using BooksArchive.Domain.Models;

namespace BooksArchive.Api.Interfaces;

public interface IUserLoginService
{
    Task<User> CreateAccountAsync(string username, string email, string password);
}
