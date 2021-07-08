using EFCore.BulkExtensions.SqlAdapters;
using EFCore.BulkExtensions.Sqlite.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure;

// ReSharper disable once CheckNamespace
namespace Microsoft.EntityFrameworkCore
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static SqliteDbContextOptionsBuilder UseBulkExtensions(this SqliteDbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseBulkExtensions<SqliteDbContextOptionsBuilder, SqliteBulkExtensionsOptionsExtension>();
    }
}
