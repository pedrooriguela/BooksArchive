using BooksArchive.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace BooksArchive.Domain.Models.Books;

public class Book : Entity
{
    public Book(
        string title,
        string author,
        string genre,
        Guid id)
    {
        Id = id;
        Title = title;
        Author = author;
        Genre = genre;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }

    public class Builder
    {
        public static Book Create(string title, string author, string genre) =>
            new(title, author, genre, Guid.NewGuid());
    }
}