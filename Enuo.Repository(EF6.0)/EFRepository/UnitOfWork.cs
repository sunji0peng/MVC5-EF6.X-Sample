using System;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Enuo.Repository.EF6
{
    internal class UnitOfWork : IUnitOfWork
    {
        private DbContext dbContext;
        private DbTransaction transaction;

        public UnitOfWork(DbContext ctx)
        {
            dbContext = ctx;
        }

        public bool IsInTransaction
        {
            get
            {
                return transaction != null;
            }
        }
        /// <summary>
        /// 打开连接
        /// </summary>
        private void OpenConnection()
        {
            if (((IObjectContextAdapter)dbContext).ObjectContext.Connection.State != ConnectionState.Open)
            {
                ((IObjectContextAdapter)dbContext).ObjectContext.Connection.Open();
            }
        }
        /// <summary>
        /// 释放当前事务
        /// </summary>
        private void ReleaseCurrentTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }
        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (transaction != null)
            {
                OpenConnection();
                transaction = ((IObjectContextAdapter)dbContext).ObjectContext.Connection.BeginTransaction(isolationLevel);
            }
        }

        public void CommitTransaction()
        {
            if (transaction == null)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running");
            }
            try
            {
                ((IObjectContextAdapter)dbContext).ObjectContext.SaveChanges();
                transaction.Commit();
                ReleaseCurrentTransaction();
            }
            catch
            {
                RollBackTransaction();
                throw;
            }
        }
        private bool disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (disposed) return;
            disposed = true;
        }
        public void RollBackTransaction()
        {
            if (transaction == null)
            {
                throw new ApplicationException("Cannot roll back a transaction while there is no transaction running.");
            }
            if (IsInTransaction)
            {
                transaction.Rollback();
                ReleaseCurrentTransaction();
            }
        }
    }
}
