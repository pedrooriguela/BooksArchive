using BooksArchive.Domain.Models.Books;

namespace BooksArchive.Domain.Interfaces;

public interface IBookRepository
{
   Task AddAsync(Book book);
   Task<bool> DeleteAsync(Guid id);
   Task <bool> UpdateAsync(Guid id, Book book);
   Task<Book?> GetByIdAsync(Guid id);
   Task<List<Book>> GetByTitleAsync(string title);
   Task<List<Book>> GetByAuthorAsync(string author);
   Task<List<Book>> GetByGenreAsync(string genre);
}