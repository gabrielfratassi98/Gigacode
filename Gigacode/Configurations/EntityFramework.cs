using Gigacode.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Gigacode.Services.Configurations
{
    public static class EntityFramework
    {
        public static void ConnectionDbSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            var stringConexao = configuration.GetConnectionString("DatabaseSql");

            services.AddDbContext<ApplicationContext>(opt => opt.UseSqlServer(stringConexao));
        }
    }
}