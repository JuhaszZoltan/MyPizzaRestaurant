﻿namespace MyPizzaRestaurant.Models;

public interface IRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id, QueryOptiopns<T> options);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
