using EFCore.BulkExtensions.SqlAdapters;
using EFCore.BulkExtensions.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkBulkExtensionsSqlServer(this IServiceCollection services)
        {
            services.TryAddSingleton<SqlAdapterFactory>();
            services.AddSingleton<SqlServerOperationsAdapter>();
            services.AddSingleton<SqlServerQueryBuilderSpecialization>();
            services.AddSingleton(new SqlAdapterRegistration(typeof(SqlServerDbContextOptionsBuilder).Assembly.GetName().Name,
                typeof(SqlServerOperationsAdapter), typeof(SqlServerQueryBuilderSpecialization)));
            return services;
        }
    }
}
