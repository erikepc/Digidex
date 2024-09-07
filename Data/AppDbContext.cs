using Joke.Models;
using Microsoft.EntityFrameworkCore;

namespace Joke.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public Joke<Tipo> Tipos { get; set; }
    public Joke<Planets> Planetss { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
