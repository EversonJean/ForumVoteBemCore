using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Data.Context;
using Domain.Entities.Base;
using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected BaseContext Db;
        protected DbSet<T> DbSet;

        public Repository(BaseContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public virtual void Add(T obj)
        {
            DbSet.Add(obj);
        }

        public virtual void Update(T obj)
        {
            Db.Update(obj);
        }

        public virtual void Remove(int Id)
        {
            DbSet.Remove(DbSet.Find(Id));
        }

        public virtual T GetById(int Id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }

        public T GetByIdWidthIncludes<TProperty>(int Id, Expression<Func<T, TProperty>>[] includes)
        {
            var query = DbSet.AsQueryable();

            foreach (var include in includes)
                DbSet.Include(include);

            return query.AsNoTracking().FirstOrDefault(x => x.Id == Id);
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }
    }
}
