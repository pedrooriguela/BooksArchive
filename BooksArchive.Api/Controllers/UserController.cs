using BooksArchive.Domain.Models;
using BooksArchive.Infra.Interfaces;
using BooksArchive.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BooksArchive.Api.Controllers;

[ApiController]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;

    public UserController(
        IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("api/users/AddUser/{name}/{email}/{password}")]
    public async Task<IActionResult> AddUserAsync(string name, string email, string password)
    {
        var user = Domain.Models.User.Builder.Create(name, email, password);
        await _userRepository.AddAsync(user);
        return Ok(user);
    }
}
