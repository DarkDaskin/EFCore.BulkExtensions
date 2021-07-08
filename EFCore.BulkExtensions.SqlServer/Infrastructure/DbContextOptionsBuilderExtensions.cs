using EFCore.BulkExtensions.SqlAdapters;
using EFCore.BulkExtensions.SqlServer.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static SqlServerDbContextOptionsBuilder UseBulkExtensions(this SqlServerDbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseBulkExtensions<SqlServerDbContextOptionsBuilder, SqlServerBulkExtensionsOptionsExtension>();
    }
}
