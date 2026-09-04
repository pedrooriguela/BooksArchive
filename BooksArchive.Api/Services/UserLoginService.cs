using BooksArchive.Api.Dtos;
using BooksArchive.Api.Interfaces;
using BooksArchive.Domain.Exceptions;
using BooksArchive.Domain.Models.Users;
using BooksArchive.Infra.Interfaces;

namespace BooksArchive.Api.Services;
public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _userRepository;

    public UserLoginService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateAccountAsync(CreateUserRequestDto createUserRequestDto)
    {
        if (_userRepository.GetByUsername(createUserRequestDto.Name) != null || _userRepository.GetByEmail(createUserRequestDto.Email) != null)
            throw new UsernameAlreadyInUseException();

        var newUser = User.Builder.Create(createUserRequestDto.Name, createUserRequestDto.Email, createUserRequestDto.Password);
        await _userRepository.AddAsync(newUser);
        return newUser;
    }

    public User LogIn(LogInUserRequestDto logInUserRequestDto)
    {
        var user = _userRepository.GetByUsername(logInUserRequestDto.Name);

        if (user == null || user.Password != logInUserRequestDto.Password)
            throw new WrongUsernameOrPasswordException();

        return user;
    }

}
