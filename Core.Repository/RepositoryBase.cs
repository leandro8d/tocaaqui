using Serilog;
using Serilog.Events;
using Services.Infrastructure;
using System;

namespace Core.Repository
{
    public class RepositoryBase<TEntity>
    {
        private AppSessionFactory Session;
        public RepositoryBase() {
            
        }
        public Get() {
            var section = sessao.OpenSession();
            var transaction = section.BeginTransaction();
            var query = section.CreateSQLQuery($"select * from login where login = '{usr._Login}' and senha = '{usr.Senha}'").AddEntity(typeof(Login)); ;
            var result = query.UniqueResult<Login>();

            return Json(result);
        }


    }
}
