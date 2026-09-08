using BooksArchive.Domain.Models.Users;
using BooksArchive.Domain.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace BooksArchive.Api.Infra.Database;

public class BooksArchiveDbContext : DbContext
{
    public BooksArchiveDbContext(
        DbContextOptions<BooksArchiveDbContext> options
        ) : base(options) { }

    public DbSet<User> Users => Set<User>();
    
    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
    }
}
