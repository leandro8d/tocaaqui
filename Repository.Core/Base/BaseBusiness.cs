using NHibernate;
using Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public abstract class BaseBusiness<TEntity> where TEntity : class, new()
    {
        protected BaseBusiness()
        {
        }
        public TEntity Load(object pk)
        {
            using (ISession session = DataBase.OpenSession())
            {
                return (TEntity)session.Load(typeof(TEntity), pk);
            }
        }
        public void Delete(object pk)
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
        public void Save(object obj)
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
        public List<TEntity> ToList()
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
