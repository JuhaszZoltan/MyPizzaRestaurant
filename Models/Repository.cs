﻿
using Microsoft.EntityFrameworkCore;
using MyPizzaRestaurant.Data;

namespace MyPizzaRestaurant.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext _context { get; set; }
        private DbSet<T> _dbSet { get; set; }

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id, QueryOptiopns<T> options)
        {
            IQueryable<T> query = _dbSet;
            //TODO::: check options
            foreach(string include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            var key = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();

            string primaryKeyName = key?.Name;

            return await query.FirstOrDefaultAsync(e => EF.Property<int>(e, primaryKeyName) == id);

        }

        public async Task UpdateAsync(T entity)
        {
            //TODO
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
