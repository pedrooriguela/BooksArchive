using MoviesArchive.Domain.Models.Books;
using MoviesArchive.Domain.Models.Books.Dtos;

namespace MoviesArchive.Domain.Interfaces;

public interface IBookRepository
{
   Task AddAsync(BookCreationRequestDto newBook);
   Task<bool> DeleteAsync(Guid id);
   Task <bool> UpdateAsync(Guid id, Book book);
   Task<Book?> GetByIdAsync(Guid id);
   Task<List<Book>> SearchBooksAsync(BookSearchRequestDto filter);
}