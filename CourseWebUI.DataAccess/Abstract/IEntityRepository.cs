using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CourseWebUI.Entities.Abstract;

namespace CourseWebUI.DataAccess.Abstract
{
    public interface IEntityRepository<T>
    where T: IEntity,new()
    {
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
