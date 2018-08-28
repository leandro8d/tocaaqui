using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using System.Reflection;

namespace Services.Infrastructure
{
    public class AppSessionFactory
    {
        public Configuration Configuration { get; }
        public ISessionFactory SessionFactory { get; }

        public AppSessionFactory(Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            NHibernate.NHibernateLogger.SetLoggersFactory(new NHibernateToMicrosoftLoggerFactory(loggerFactory));

            //var mapper = new ModelMapper();
            //mapper.adda();
            //var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

            Configuration = new Configuration();
            Configuration.DataBaseIntegration(db =>
            {
                db.ConnectionString = @"Server=127.0.0.1;Port=5432;User ID=postgres;Password=123456;Database=postgres";
                db.Dialect<PostgreSQLDialect>();
                db.Driver<NpgsqlDriver>();
            }).AddAssembly("Services");
            
            Configuration.SessionFactory().GenerateStatistics();

            SessionFactory = Configuration.BuildSessionFactory();
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
