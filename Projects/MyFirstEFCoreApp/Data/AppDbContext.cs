using Models;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{

    public DbSet<Book> Books { get; set; }
    private const string _connectionString = "Server=;Database=;Trusted_Connection=ture";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}