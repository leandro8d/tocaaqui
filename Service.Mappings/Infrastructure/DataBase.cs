using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Reflection;

namespace Services.Infrastructure
{
    public static class DataBase
    {
      

        //var mapper = new ModelMapper();
        //mapper.adda();
        //var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
        private static ISessionFactory _sessionFactory;



        private static ISessionFactory SessionFactory
        {
            get
            {
               var Configuration = new Configuration();
                if (_sessionFactory == null)
                {
                    Configuration.DataBaseIntegration(db =>
                    {
                        db.ConnectionString = @"Server=127.0.0.1;Port=5432;User ID=postgres;Password=123456;Database=tocaaqui";
                        db.Dialect<PostgreSQLDialect>();
                        db.Driver<NpgsqlDriver>();
                    }).AddAssembly("Services");

                    _sessionFactory = Configuration.BuildSessionFactory();
                    Configuration.SessionFactory().GenerateStatistics();
                    Configuration.Cache(x => x.UseQueryCache = false);
                }
                return _sessionFactory;
            }
        }


        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
