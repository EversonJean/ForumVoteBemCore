using System;
using Domain.Entities.Base;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Domain.Interfaces.Base
{
    public interface IRepository<T>: IDisposable where T : Entity
    {
        void Add(T obj);

        T GetById(int Id);
        
        T GetByIdWidthIncludes<TProperty>(int Id, Expression<Func<T, TProperty>>[] includes);

        IEnumerable<T> GetAll();

        void Update(T obj);

        void Remove(int Id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        int SaveChanges();
    }
}
