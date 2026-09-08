using BooksArchive.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BooksArchive.Api.Controllers;

[ApiController]
public class BooksController : Controller
{
    private readonly IOpenLibraryConsumer _openLibraryConsumer;

    public BooksController(IOpenLibraryConsumer openLibraryConsumer)
    {
        _openLibraryConsumer = openLibraryConsumer;
    }

    [HttpGet("/books/search/{name}")]
    public async Task<IActionResult> SearchBookByNameAsync(string name)
    {
        var response = await _openLibraryConsumer.GetBook(name);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return Ok(json);
    }
}
