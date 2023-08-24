using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Database.Data
{
    public interface IGenericRepository<T> where T : class,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        void UpdateColumn<TProperty>(T entity, Expression<Func<T, TProperty>> propertyExpression, TProperty value);
    }
}
