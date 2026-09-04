using BooksArchive.Api.Interfaces;
using BooksArchive.Domain.Models;
using BooksArchive.Infra.Interfaces;
using BooksArchive.Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BooksArchive.Api.Controllers;

[ApiController]
public class UserController : Controller
{
    private readonly IUserRepository _userRepository;
    private readonly IUserLoginService _userLoginService;

    public UserController(
        IUserRepository userRepository,
        IUserLoginService userLoginService)
    {
        _userRepository = userRepository;
        _userLoginService = userLoginService;
    }

    [HttpPost("api/users/SignUp/{name}/{email}/{password}")]
    public async Task<IActionResult> SignUpAsync(string name, string email, string password)
    {
        var user = await _userLoginService.CreateAccountAsync(name, email, password);
        return Ok(user);
    }
}
