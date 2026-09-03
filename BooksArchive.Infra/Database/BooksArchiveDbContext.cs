using Microsoft.EntityFrameworkCore;
using  BooksArchive.Domain.Models;

namespace BooksArchive.Api.Infra.Database;

public class BooksArchiveDbContext : DbContext
{
    public BooksArchiveDbContext(
        DbContextOptions<BooksArchiveDbContext> options
        ) : base(options) { }

    public DbSet<User> Users => Set<User>();
}
