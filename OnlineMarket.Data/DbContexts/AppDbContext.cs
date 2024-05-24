using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    
}
