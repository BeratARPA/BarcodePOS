using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Database.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private readonly SQLContext _context = new SQLContext();

        public GenericRepository(SQLContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void AddAll(List<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteAll(List<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            return _context.Set<T>().Where(filter).FirstOrDefault();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
                ? _context.Set<T>().AsNoTracking().ToList()
                : _context.Set<T>().Where(filter).ToList();
        }

        public void UpdateColumn<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression, TProperty value)
        {
            _context.Entry(entity).Property(propertyExpression).CurrentValue = value;
            _context.SaveChanges();
        }     
    }
}
