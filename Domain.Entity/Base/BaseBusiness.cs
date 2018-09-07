using NHibernate;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entity
{
    public abstract class BaseBusiness<TEntity> where TEntity : class
    {
       // protected ISession session { get { return DataBase.OpenSession(); } }
        public BaseBusiness()
        {
        }
        public virtual TEntity Load(object pk)
        {
            using (ISession session = DataBase.OpenSession())
            {
                return (TEntity)session.Load(typeof(TEntity), pk);
            }
        }
        public virtual void Delete(object pk)
        {
            using (ISession session = DataBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(pk);
                    transaction.Commit();
                }
            }
        }
        public virtual void Save(object obj)
        {
            using (ISession session = DataBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(obj);
                    transaction.Commit();
                }
            }
        }
        public virtual List<TEntity> ToList()
        {
            List<TEntity> resultList = new List<TEntity>();
            using (ISession session = DataBase.OpenSession())
            {
                var objects = session
                    .CreateCriteria(typeof(TEntity))
                    .List();
                foreach (object obj in objects)
                {
                    resultList.Add((TEntity)obj);
                }
            }
            return resultList;
        }

    }
}
