﻿using NHibernate;
using Repository.Epecification;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Linq;

namespace Repository.Base
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable
    {
        protected ISession _session = null;
        protected ITransaction _transaction = null;
        public RepositoryBase()
        {
            _session = DataBase.OpenSession();
        }
        public RepositoryBase(ISession session)
        {
            _session = session;
        }
        #region Transaction and Session Management Methods
        public void BeginTransaction()
        {
            _transaction = _session.BeginTransaction();
        }
        public void CommitTransaction()
        {
            // _transaction will be replaced with a new transaction            // by NHibernate, but we will close to keep a consistent state.
            _transaction.Commit();
            CloseTransaction();
        }
        public void RollbackTransaction()
        {
            // _session must be closed and disposed after a transaction            // rollback to keep a consistent state.
            _transaction.Rollback();
            CloseTransaction();
            CloseSession();
        }
        private void CloseTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }
        private void CloseSession()
        {
            _session.Close();
            _session.Dispose();
            _session = null;
        }
        #endregion
        #region IRepository Members
        public virtual void Save(TEntity obj)
        {
            _session.SaveOrUpdate(obj);
            this.BeginTransaction();
        }
        public virtual void Delete(TEntity obj)
        {
            _session.Delete(obj);
            this.BeginTransaction();
        }
        public virtual object GetById(int objId)
        {
            this.BeginTransaction();
            return _session.Load(typeof(TEntity), objId);
            
        }
        public virtual IQueryable<TEntity> ToList()
        {
            return (from entity in _session.Query<TEntity>() select entity);
        }
        #endregion
        #region IDisposable Members
        public void Dispose()
        {
            if (_transaction != null)
            {
                // Commit transaction by default, unless user explicitly rolls it back.
                // To rollback transaction by default, unless user explicitly commits,                // comment out the line below.
                CommitTransaction();
            }
            if (_session != null)
            {
                _session.Flush(); // commit session transactions
                CloseSession();
            }
        }
        #endregion
    }
}
