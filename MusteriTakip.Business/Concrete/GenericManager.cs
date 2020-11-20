using MusteriTakip.Business.Services;
using MusteriTakip.DataAccess.Interfaces;
using MusteriTakip.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusteriTakip.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity>
        where TEntity : class, ITable, new()
    {

        private readonly IGenericDal<TEntity> _genericDal;

        public GenericManager(IGenericDal<TEntity> genericDal)
        {
            _genericDal = genericDal;
        }

        public void Add(TEntity entity)
        {
            _genericDal.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _genericDal.Delete(entity);
        }

        public void Update(TEntity entity)
        {
            _genericDal.Update(entity);
        }

        public int EntityCount()
        {
            return _genericDal.EntityCount();
        }

        public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return _genericDal.GetAllAsync(expression);
        }

        public IQueryable<TEntity> GetQueryable( Expression<Func<TEntity, bool>> expression = null)
        {
            return _genericDal.GetQueryable(expression);
        }

        public virtual Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
        {
            return _genericDal.GetAsync(expression);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _genericDal.GetByIdAsync(id);
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _genericDal.SaveChangesAsync();
        }

      
    }
}
