using BooksArchive.Domain.Exceptions;
using BooksArchive.Domain.Interfaces;
using BooksArchive.Domain.Models.Users.Dtos;
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

    [HttpPost("api/users/signup")]
    public async Task<IActionResult> SignUpAsync([FromBody] CreateUserRequestDto createUserRequestDto)
    {
        var user = await _userLoginService.CreateAccountAsync(createUserRequestDto);
        return Ok(user);
    }

    [HttpGet("api/users/signin")]
    public IActionResult SignInAsync([FromQuery] LogInUserRequestDto request)
    {
        try
        {
            var token = _userLoginService.LogIn(request);
            return Ok(new { token });
        }
        catch ( WrongUsernameOrPasswordException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        
    }
}
