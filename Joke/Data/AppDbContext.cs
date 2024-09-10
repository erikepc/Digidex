using Joke.Models;
using Microsoft.EntityFrameworkCore;

namespace Joke.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Tipo> Tipos { get; set; }
    public DbSet<Planeta> Planetas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
