using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.BulkExtensions.SqlAdapters
{
    internal static class DbContextAdapterExtensions
    {
        public static ISqlOperationsAdapter GetSqlOperationsAdapter(this DbContext context) =>
            context.GetService<SqlAdapterFactory>().GetSqlOperationsAdapter(context);

        public static IQueryBuilderSpecialization GetQueryBuilderSpecialization(this DbContext context) =>
            context.GetService<SqlAdapterFactory>().GetQueryBuilderSpecialization(context);
    }
}
