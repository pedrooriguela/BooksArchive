using BooksArchive.Domain.Models.Books;
using BooksArchive.Domain.Models.Books.Dtos;

namespace BooksArchive.Domain.Interfaces;

public interface IBookRepository
{
   Task AddAsync(BookCreationRequestDto newBook);
   Task<bool> DeleteAsync(Guid id);
   Task <bool> UpdateAsync(Guid id, Book book);
   Task<Book?> GetByIdAsync(Guid id);
   Task<List<Book>> SearchBooksAsync(BookSearchRequestDto filter);
}