using System;
using System.Linq;
using System.Linq.Expressions;

namespace CarSales.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression);
    }
}