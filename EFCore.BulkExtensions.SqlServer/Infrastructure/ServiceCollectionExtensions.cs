using EFCore.BulkExtensions.SqlAdapters;
using EFCore.BulkExtensions.SqlServer;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEntityFrameworkBulkExtensionsSqlServer(this IServiceCollection services) =>
            services
                .AddSingleton<ISqlOperationsAdapter, SqlServerOperationsAdapter>()
                .AddSingleton<IQueryBuilderSpecialization, SqlServerQueryBuilderSpecialization>();
    }
}
