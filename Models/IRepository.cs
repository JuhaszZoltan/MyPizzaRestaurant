namespace MyPizzaRestaurant.Models;

public interface IRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id, QueryOptiopns<T> options);
    Task AddAsync(Task entity);
    Task UpdateAsync(Task entity);
    Task DeleteAsync(int id);
}
