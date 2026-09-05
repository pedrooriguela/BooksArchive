using Microsoft.EntityFrameworkCore;
using BooksArchive.Domain.Models.Users;

namespace BooksArchive.Api.Infra.Database;

public class BooksArchiveDbContext : DbContext
{
    public BooksArchiveDbContext(
        DbContextOptions<BooksArchiveDbContext> options
        ) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
    }
}
