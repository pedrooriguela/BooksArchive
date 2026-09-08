namespace BooksArchive.Domain.Models.Books.Dtos;

public class BookCreationRequestDto
{
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Subject { get; set; }
    public required string Key { get; set; }
}