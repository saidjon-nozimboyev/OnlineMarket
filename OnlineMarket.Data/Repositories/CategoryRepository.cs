using Microsoft.EntityFrameworkCore;
using OnlineMarket.Data.DbContexts;
using OnlineMarket.Data.Interfaces;
using OnlineMarket.Domain.Entities;

namespace OnlineMarket.Data.Repositories;

public class CategoryRepository(AppDbContext dbContext) :
    GenericRepository<Category>(dbContext), ICategoryRepository
{
    public async Task<IEnumerable<Category?>> GetByNameAsync(string categoryName)
    {
        return await _dbContext.Categories
                               .Where(x => x.CategoryName == categoryName)
                               .ToListAsync();
    }

    public async Task<bool> IsCategoryExistsAsync(string categoryName)
    {
        var category = await _dbContext.Categories.FirstOrDefaultAsync(x=> x.CategoryName == categoryName);
        return category != null;
    }
}
