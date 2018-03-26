using Contracts;
using LoggerService;
using Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace CDEEnablementReport.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void ConfigureLoggerService(this IServiceCollection services) {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureMSSqlContext(this IServiceCollection services, IConfiguration config) {
            var connectionString = config["mssqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services) {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureCodePageProvider(this IServiceCollection services) {

        }
    }
}
