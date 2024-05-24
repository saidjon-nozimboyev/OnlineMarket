using System.Linq.Expressions;

namespace OnlineMarket.Data.Interfaces;

public interface IGenericRepository<T>
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> GetByIdAsync(int id); 
    Task<IQueryable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
}