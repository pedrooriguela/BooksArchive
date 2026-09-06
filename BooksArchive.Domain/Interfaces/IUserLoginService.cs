using BooksArchive.Domain.Models.Users;
using BooksArchive.Domain.Models.Users.Dtos;

namespace BooksArchive.Domain.Interfaces;

public interface IUserLoginService
{
    Task<string> CreateAccountAsync(CreateUserRequestDto createUserRequestDto);
    string LogIn(LogInUserRequestDto logInUserRequestDto);
}
