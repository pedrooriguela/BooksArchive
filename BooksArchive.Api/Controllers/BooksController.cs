using BooksArchive.Domain.Interfaces;
using BooksArchive.Domain.Models.Books;
using BooksArchive.Domain.Models.Books.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BooksArchive.Api.Controllers;

[ApiController]
public class BooksController : Controller
{
    private readonly IOpenLibraryConsumer _openLibraryConsumer;
    private readonly IBookRepository _bookRepository;

    public BooksController(IOpenLibraryConsumer openLibraryConsumer,
        IBookRepository  bookRepository)
    {
        _openLibraryConsumer = openLibraryConsumer;
        _bookRepository = bookRepository;
    }

    [HttpGet("/books/search/{name}")]
    public async Task<IActionResult> SearchBookByNameAsync(string name)
    {
        var response = await _openLibraryConsumer.GetBook(name);
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();
        return Ok(json);
    }

    [HttpGet("/books/find/")]
    public async Task<IActionResult> SearchBooksAsync([FromQuery]BookSearchRequestDto filter)
    {
        var response = await _bookRepository.SearchBooksAsync(filter); 
        return Ok(response);
    }
    
    [HttpPost("/books/add/")]
    public async Task<IActionResult> AddBookAsync([FromQuery]BookCreationRequestDto newBook)
    {
        await _bookRepository.AddAsync(newBook); 
        return Ok();
    }
}
