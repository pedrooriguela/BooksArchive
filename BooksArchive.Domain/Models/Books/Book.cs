using BooksArchive.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;
using BooksArchive.Domain.Enums;

namespace BooksArchive.Domain.Models.Books;

public class Book : Entity
{
    public Book(
        string title,
        string author,
        string subject,
        string key,
        Guid id)
    {
        Id = id;
        Title = title;
        Author = author;
        Subject = subject;
        Key = key;
    }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Subject { get; set; }
    public string Key { get; set; }
    
    public class Builder
    {
        public static Book Create(string title, string author, string subject, string key) =>
            new(title, author, subject, key, Guid.NewGuid());
    }

}
