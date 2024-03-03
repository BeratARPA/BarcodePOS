using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Database.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        public T Add(T entity)
        {
            using (SQLContext context = new SQLContext())
            {
                context.Entry(entity).State = EntityState.Added;
                context.SaveChanges();

                return entity;
            }
        }

        public List<T> AddAll(List<T> entities)
        {
            using (SQLContext context = new SQLContext())
            {
                context.Set<T>().AddRange(entities);
                context.SaveChanges();

                return entities;
            }
        }

        public void Update(T entity)
        {
            using (SQLContext context = new SQLContext())
            {
                context.Entry(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (SQLContext context = new SQLContext())
            {
                context.Entry(entity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void DeleteAll(List<T> entities)
        {
            using (SQLContext context = new SQLContext())
            {
                context.Set<T>().RemoveRange(entities);
                context.SaveChanges();
            }
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            using (SQLContext context = new SQLContext())
            {
                return context.Set<T>().Where(filter).FirstOrDefault();
            }
        }

        public T GetById(int id)
        {
            using (SQLContext context = new SQLContext())
            {
                return context.Set<T>().Find(id);
            }
        }

        public List<T> GetAllAsNoTracking(Expression<Func<T, bool>> filter = null)
        {
            using (SQLContext context = new SQLContext())
            {
                return filter == null
                ? context.Set<T>().AsNoTracking().ToList()
                : context.Set<T>().AsNoTracking().Where(filter).ToList();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (SQLContext context = new SQLContext())
            {
                return filter == null
                ? context.Set<T>().AsNoTracking().ToList()
                : context.Set<T>().Where(filter).ToList();
            }
        }

        public void UpdateColumn<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression, TProperty value)
        {
            using (SQLContext context = new SQLContext())
            {
                context.Entry(entity).Property(propertyExpression).CurrentValue = value;
                context.SaveChanges();
            }
        }

        public TProperty GetColumnValue<T, TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression)
        {
            var propertyName = ((MemberExpression)propertyExpression.Body).Member.Name;
            var propertyValue = entity.GetType().GetProperty(propertyName).GetValue(entity, null);
            return (TProperty)propertyValue;
        }
    }
}
