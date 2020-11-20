using Microsoft.EntityFrameworkCore;
using MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Context;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MusteriTakip.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class GenericRepository<TEntity> : IGenericDal<TEntity>
        where TEntity : class, ITable, new()
    {

        private readonly DbContext _context;

        public GenericRepository(MusteriTakipContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            var added = _context.Entry(entity);
            added.State = EntityState.Added;
        }

        public void Delete(TEntity entity)
        {
            var deleted = _context.Entry(entity);
            deleted.State = EntityState.Deleted;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);

        }

        public void Update(TEntity entity)
        {
            var updated = _context.Entry(entity);
            updated.State = EntityState.Modified;
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return expression != null
                ? await _context.Set<TEntity>().Where(expression).ToListAsync()
                : await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public IQueryable<TEntity> GetQueryable( Expression<Func<TEntity, bool>> expression = null)
        {
            return expression != null ?
                 _context.Set<TEntity>().Where(expression):
                 _context.Set<TEntity>();

        }

        public int EntityCount()
        {
            return _context.Set<TEntity>().Count();
        }
    }
}
