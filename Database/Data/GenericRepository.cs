using Database.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Database.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        private SQLContext _context;

        public GenericRepository(SQLContext context)
        {
            _context = context;
        }

        public T Add(T entity)
        {
            try
            {                
                _context.Entry(entity).State = EntityState.Added;
                _context.SaveChanges();

                Logger.Log($"Added a new {typeof(T).Name}: {entity}");

                return entity;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }           
        }

        public List<T> AddAll(List<T> entities)
        {
            try
            {
                _context.Set<T>().AddRange(entities);
                _context.SaveChanges();

                Logger.Log($"Added a new {typeof(T).Name}: {entities}");

                return entities;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

                Logger.Log($"Updated a {typeof(T).Name}: {entity}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public void UpdateColumn<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression, TProperty value)
        {
            try
            {
                _context.Entry(entity).Property(propertyExpression).CurrentValue = value;
                _context.SaveChanges();

                Logger.Log($"Updated {typeof(T).Name} Column: {entity}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Deleted;
                _context.SaveChanges();

                Logger.Log($"Deleted a {typeof(T).Name}: {entity}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public void DeleteAll(List<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
                _context.SaveChanges();

                Logger.Log($"Deleted a {typeof(T).Name}: {entities}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public T Get(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                var entity = _context.Set<T>().Where(filter).FirstOrDefault();

                Logger.Log($"Received a {typeof(T).Name}: {entity}");

                return entity;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }           
        }

        public T GetAsNoTracking(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                var entity = _context.Set<T>().AsNoTracking().Where(filter).FirstOrDefault();

                Logger.Log($"Received a {typeof(T).Name}: {entity}");

                return entity;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public T GetById(int id)
        {
            try
            {
                var entity = _context.Set<T>().Find(id);

                Logger.Log($"Received a {typeof(T).Name}: {entity}");

                return entity;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public List<T> GetAllAsNoTracking(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                var entities = filter == null
                    ? _context.Set<T>().AsNoTracking().ToList()
                    : _context.Set<T>().AsNoTracking().Where(filter).ToList();

                Logger.Log($"Received a {typeof(T).Name}: {entities}");

                return entities;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            try
            {
                var entities = filter == null
                    ? _context.Set<T>().AsNoTracking().ToList()
                    : _context.Set<T>().Where(filter).ToList();

                Logger.Log($"Received a {typeof(T).Name}: {entities}");

                return entities;
            }
            catch (Exception ex)
            {
                Logger.Log($"Error occurred: {ex.Message}");
                throw;
            }
        }     
    }
}