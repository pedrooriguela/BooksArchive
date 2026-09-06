using BooksArchive.Domain.Models.Users;
using BooksArchive.Domain.Models.Users.Dtos;

namespace BooksArchive.Domain.Interfaces;

public interface IUserLoginService
{
    Task CreateAccountAsync(CreateUserRequestDto createUserRequestDto);
    string LogIn(LogInUserRequestDto logInUserRequestDto);
}
