using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAPI.Context;
using WebAPI.Entities;
using WebAPI.Interface;
using WebAPI.Interface.Repository;

namespace WebAPI.Implementation.Repositories
{
    public abstract class BaseRepository<T>:IBaseRepository<T> where T : BaseEntity, new()
    {
        protected ApplicationContext _context;

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Any(expression);
        }

        public T Get(int id)
        {
            return _context.Set<T>().FirstOrDefault(x =>x.Id == id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }

        public IList<T> Get(IList<int> ids)
        {
            return _context.Set<T>().Where(x => ids.Contains(x.Id)).ToList();
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>().ToList().AsQueryable();
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList().AsQueryable();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}