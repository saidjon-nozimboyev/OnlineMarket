using Microsoft.EntityFrameworkCore;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.DbContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    DbSet<User> Users { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<Category> Categories { get; set; }
}