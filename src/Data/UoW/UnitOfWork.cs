using Data.Context;
using Domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseContext _contexto;
        private IDbContextTransaction _transaction;

        public UnitOfWork(BaseContext contexto)
        {
            _contexto = contexto;
        }

        public void BeginTransaction()
        {
            if (_transaction == null)
                _transaction = _contexto.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_contexto.ChangeTracker.HasChanges())
                SaveChanges();

            if (_transaction == null) return;

            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }

        public void CommitTransaction()
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            Rollback();

            _contexto.Dispose();
        }

        public int ExecuteQuery(string sqlQuery, params object[] parameters)
        {
            return _contexto.Database.ExecuteSqlCommand(sqlQuery, parameters);
        }

        public void Rollback()
        {
            if (_transaction == null) return;

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public int SaveChanges()
        {
            return _contexto.SaveChanges();
        }
    }
}
