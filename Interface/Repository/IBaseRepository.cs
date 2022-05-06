using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAPI.Entities;

namespace WebAPI.Interface.Repository
{
    public interface IBaseRepository<T>where T:BaseEntity, new()
    {
        T Get(int id);
        T Get(Expression<Func<T, bool>> expression);
        IList<T> GetAll();
        IList<T> GetAll(Expression<Func<T, bool>> expression);

        IList<T> Get(IList<int> ids);
        bool Exists(Expression<Func<T, bool>> expression);

        IQueryable<T> Query();

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        IQueryable<T> Query(Expression<Func<T, bool>> expression);
    }
}