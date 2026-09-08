using BooksArchive.Domain.Enums;

namespace BooksArchive.Domain.Models.Books.Dtos;

public class BookSearchRequestDto
{
    public string? Author { get; set; }
    public string? Title { get; set; }
    public string? Subject { get; set; }
}