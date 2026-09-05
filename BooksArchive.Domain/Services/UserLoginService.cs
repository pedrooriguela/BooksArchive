using BooksArchive.Domain.Exceptions;
using BooksArchive.Domain.Interfaces;
using BooksArchive.Domain.Models.Users;
using BooksArchive.Domain.Models.Users.Dtos;

namespace BooksArchive.Domain.Services;
public class UserLoginService : IUserLoginService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasherService _passwordHasherService;

    public UserLoginService(
        IUserRepository userRepository,
        IPasswordHasherService passwordHasherService)
    {
        _userRepository = userRepository;
        _passwordHasherService = passwordHasherService;
    }

    public async Task<User> CreateAccountAsync(CreateUserRequestDto createUserRequestDto)
    {
        if (_userRepository.GetByUsername(createUserRequestDto.Name) != null || _userRepository.GetByEmail(createUserRequestDto.Email) != null)
            throw new UsernameAlreadyInUseException();

        var newUser = User.Builder.Create(createUserRequestDto.Name, createUserRequestDto.Email);

        var hashedPassword = _passwordHasherService.Hash(newUser, createUserRequestDto.Password);

        newUser.SetPassword(hashedPassword);

        await _userRepository.AddAsync(newUser);
        return newUser;
    }

    public User LogIn(LogInUserRequestDto logInUserRequestDto)
    {
        var user = _userRepository.GetByUsername(logInUserRequestDto.Name);

        if (user == null)
            throw new WrongUsernameOrPasswordException();

        if(!_passwordHasherService.Compare(user, user.Password, logInUserRequestDto.Password))
            throw new WrongUsernameOrPasswordException();

        return user;
    }

}
