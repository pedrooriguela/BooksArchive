using BooksArchive.Api.Dtos;
using BooksArchive.Domain.Models.Users;

namespace BooksArchive.Api.Interfaces;

public interface IUserLoginService
{
    Task<User> CreateAccountAsync(CreateUserRequestDto createUserRequestDto);
    User LogIn(LogInUserRequestDto logInUserRequestDto);
}
