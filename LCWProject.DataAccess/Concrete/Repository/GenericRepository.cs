using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LCWProject.DataAccess.Concrete.Context;
using LCWProject.DataAccess.Interfaces;
using LCWProject.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LCWProject.DataAccess.Concrete.Repository
{
    public class GenericRepository<TEntity> : IGenericService<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DemoDbContext _context;
        public GenericRepository(DemoDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _context.Set<TEntity>().Where(filter).OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }
        public async Task RemoveAsync(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }

}
