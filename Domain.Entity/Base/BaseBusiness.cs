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
        public static TEntity Load(object pk)
        {
            using (ISession session = DataBase.OpenSession())
            {
                return (TEntity)session.Load(typeof(TEntity), pk);
            }
        }
        public static void Delete(TEntity pk)
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
        public static void Save(TEntity obj)
        {
            try
            {
                using (ISession session = DataBase.OpenSession())
                {
                    var transaction = session.Transaction;

                    session.SaveOrUpdate(obj);
                    transaction.Begin();
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                throw ex;
            }
        }
        public static List<TEntity> ToList()
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
