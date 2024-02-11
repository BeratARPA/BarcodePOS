using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Database.Data
{
    public interface IGenericRepository<T> where T : class, new()
    {
        void Add(T entity);
        void AddAll(List<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void DeleteAll(List<T> entities);
        T Get(Expression<Func<T, bool>> filter = null);
        T GetById(int id);
        List<T> GetAllAsNoTracking(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void UpdateColumn<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression, TProperty value);
        TProperty GetColumnValue<T, TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression);
    }
}
