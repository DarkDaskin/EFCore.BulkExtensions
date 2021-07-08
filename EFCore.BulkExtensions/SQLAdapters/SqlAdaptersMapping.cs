using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCore.BulkExtensions.SqlAdapters
{
    [Obsolete]
    public enum DbServer
    {
        SqlServer,
        Sqlite,
    }

    [Obsolete]
    public static class SqlAdaptersMapping
    {
        public static ISqlOperationsAdapter CreateBulkOperationsAdapter(DbContext context) =>
            context.GetSqlOperationsAdapter();

        public static IQueryBuilderSpecialization GetAdapterDialect(DbContext context) =>
            context.GetQueryBuilderSpecialization();

        public static DbServer GetDatabaseType(DbContext context) => 
            Enum.Parse<DbServer>(context.Database.ProviderName.Split('.').Last());
    }
}
