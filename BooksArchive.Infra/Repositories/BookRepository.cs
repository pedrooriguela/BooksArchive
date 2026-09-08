using BooksArchive.Api.Infra.Database;
using BooksArchive.Domain.Interfaces;
using BooksArchive.Domain.Models.Books;
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

    public async Task AddAsync(Book book)
    {
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
    
    public async Task<List<Book>> GetByTitleAsync(string title)
    {
        var booksList = await _dbContext.Books.Where(p => p.Title == title).ToListAsync();
        return booksList;
    }

    public async Task<List<Book>> GetByAuthorAsync(string author)
    {
        var booksList = await _dbContext.Books.Where(p => p.Author == author).ToListAsync();
        return booksList;
    }
    
    public async Task<List<Book>> GetByGenreAsync(string genre)
    {
        var booksList = await _dbContext.Books.Where(p => p.Genre == genre).ToListAsync();
        return booksList;
    }
}