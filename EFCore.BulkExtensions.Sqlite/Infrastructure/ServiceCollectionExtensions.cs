using EFCore.BulkExtensions.SqlAdapters;
using EFCore.BulkExtensions.Sqlite;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkBulkExtensionsSqlite(this IServiceCollection services) =>
            services
                .AddSingleton<ISqlOperationsAdapter, SqliteOperationsAdapter>()
                .AddSingleton<IQueryBuilderSpecialization, SqliteQueryBuilderSpecialization>();
    }
}
