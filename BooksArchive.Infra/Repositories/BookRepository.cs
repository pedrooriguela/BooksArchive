using BooksArchive.Api.Infra.Database;
using BooksArchive.Domain.Interfaces;
using BooksArchive.Domain.Models.Books;
using BooksArchive.Domain.Models.Books.Dtos;
using Microsoft.EntityFrameworkCore;


namespace BooksArchive.Infra.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BooksArchiveDbContext _dbContext;
    public BookRepository(
        BooksArchiveDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(BookCreationRequestDto newBook)
    {
        var book = new Book(newBook.Title, newBook.Author, newBook.Subject, newBook.Key, Guid.NewGuid());
        await _dbContext.AddAsync(book);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(Guid id, Book newBook)
    {
        var book = await GetByIdAsync(id);
        if (book == null)
            return false;

        book = newBook;
        _dbContext.Update(book);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var book = GetByIdAsync(id);
        if (book == null)
            return false;

        _dbContext.Remove(book);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<Book?> GetByIdAsync(Guid id)
    {
        var book = await _dbContext.Books.FindAsync(id);
        return book;
    }

    public async Task<List<Book>> SearchBooksAsync(BookSearchRequestDto request)
    {
        var query = _dbContext.Books.AsQueryable();
        
        if (!string.IsNullOrWhiteSpace(request.Title))
        {
            query = query.Where(b => b.Title.Contains(request.Title));
        }

        if (!string.IsNullOrWhiteSpace(request.Author))
        {
            query = query.Where(b => b.Author.Contains(request.Author));
        }

        if (!string.IsNullOrWhiteSpace(request.Subject))
        {
            query = query.Where(b => b.Subject == request.Subject);
        }
        
        var booksList = await query.ToListAsync();

        return booksList;
    }
}