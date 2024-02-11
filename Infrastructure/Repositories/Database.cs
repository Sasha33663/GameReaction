using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class Database : IdentityDbContext
{
    public Database(DbContextOptions<Database> options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(a => a.UserId);
        modelBuilder.Entity<Game>().HasKey(x => x.GameId);
        
       
    
        modelBuilder.Entity<Game>()
            .HasOne(g => g.User)
            .WithMany(u => u.Games)
            .HasForeignKey(g => g.UserId); // Устанавливаем внешний ключ

        // Остальная конфигурация моделей
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<User> Users { get; set; }
}