using BooksArchive.Infra.Interfaces;
using BooksArchive.Domain.Models;
using BooksArchive.Domain.Exceptions;

namespace BooksArchive.Api.Services;
public class UserLoginService
{
    private readonly IUserRepository _userRepository;

    public UserLoginService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> SignUp(string username, string email, string password)
    {
        if (_userRepository.GetByUsername(username) != null || _userRepository.GetByEmail(email) != null)
            throw new UsernameOrEmailAlreadyExistsException();

        var newUser = User.Builder.Create(username, email, password);
        await _userRepository.AddAsync(newUser);
        return newUser;
    }

}
