using System;

namespace Domain.Interfaces.Base
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        void Rollback();

        int SaveChanges();

        void BeginTransaction();

        void CommitTransaction();

        int ExecuteQuery(string sqlQuery, params object[] parameters);
    }
}
