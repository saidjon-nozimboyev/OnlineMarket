using OnlineMarket.Application.DTOs.CategoryDTOs;

namespace OnlineMarket.Application.Interafces;

public interface ICategoryService
{
    Task CreateAsync(AddCategoryDto dto);
    Task UpdateAsync(CategoryDto dto);
    Task DeleteAsync(int id);
    Task<CategoryDto?> GetByIdAsync(int id);
    Task<IEnumerable<CategoryDto>> GetAllAsync();
    Task<IEnumerable<CategoryDto>> GetByNameAsync(string name);
}
