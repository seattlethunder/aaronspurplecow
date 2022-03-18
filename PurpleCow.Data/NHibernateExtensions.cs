using Microsoft.Extensions.DependencyInjection;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleCow.Data
{
    public static class NHibernateExtensions
    {
        public static IServiceCollection StartNHibernate(this IServiceCollection services, string connectionString)
        {
            try
            {
                var mapper = new ModelMapper();
                mapper.AddMappings(typeof(NHibernateExtensions).Assembly.ExportedTypes);
                HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

                var configuration = new Configuration();
                configuration.DataBaseIntegration(c =>
                {
                    c.Dialect<MsSql2012Dialect>();
                    c.ConnectionString = connectionString;
                    c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                    c.SchemaAction = SchemaAutoAction.Validate;
                    c.LogFormattedSql = true;
                    c.LogSqlInConsole = true;
                });
                configuration.AddMapping(domainMapping);

                var sessionFactory = configuration.BuildSessionFactory();

                services.AddSingleton(sessionFactory);
                services.AddScoped(factory => sessionFactory.OpenSession());
                services.AddScoped<IMapperSession, NHibernateMapperSession>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return services;
        }
    }
}
