using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Database : DbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
       
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(a => a.UserId);
        modelBuilder.Entity<Game>().HasKey(x => x.GameId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
}