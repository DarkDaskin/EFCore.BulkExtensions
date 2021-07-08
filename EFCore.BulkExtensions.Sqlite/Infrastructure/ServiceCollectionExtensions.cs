using EFCore.BulkExtensions.SqlAdapters;
using EFCore.BulkExtensions.Sqlite;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkBulkExtensionsSqlite(this IServiceCollection services)
        {
            services.TryAddSingleton<SqlAdapterFactory>();
            services.AddSingleton<SqliteOperationsAdapter>();
            services.AddSingleton<SqliteQueryBuilderSpecialization>();
            services.AddSingleton(new SqlAdapterRegistration(typeof(SqliteDbContextOptionsBuilder).Assembly.GetName().Name,
                typeof(SqliteOperationsAdapter), typeof(SqliteQueryBuilderSpecialization)));
            return services;
        }
    }
}
