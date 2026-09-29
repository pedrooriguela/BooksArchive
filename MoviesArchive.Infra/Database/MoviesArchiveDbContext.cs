using MoviesArchive.Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace MoviesArchive.Infra.Database;

public class MoviesArchiveDbContext : DbContext
{
    public MoviesArchiveDbContext(
        DbContextOptions<MoviesArchiveDbContext> options
        ) : base(options) { }

    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
    }
}
