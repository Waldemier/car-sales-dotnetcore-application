using System;
using System.Linq;
using System.Linq.Expressions;
using CarSales.Domain.Interfaces;

namespace CarSales.EFData.Repositories
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T: class
    {
        private readonly ApplicationContext _context;
        protected BaseRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public void Insert(T entity) => this._context.Set<T>().Add(entity);

        public void Delete(T entity) => this._context.Set<T>().Remove(entity);

        public void Update(T entity) => this._context.Set<T>().Update(entity);

        public IQueryable<T> GetAll() => this._context.Set<T>();

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) => 
            this._context.Set<T>().Where(expression);
    }
}