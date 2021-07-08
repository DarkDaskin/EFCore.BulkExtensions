using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCore.BulkExtensions.SqlAdapters
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static TOptionsBuilder UseBulkExtensions<TOptionsBuilder, TOptionsExtension>(this TOptionsBuilder optionsBuilder)
            where TOptionsBuilder : IRelationalDbContextOptionsBuilderInfrastructure
            where TOptionsExtension : class, IDbContextOptionsExtension, new()
        {
            var coreOptionsBuilder = optionsBuilder.OptionsBuilder;

            var extension = coreOptionsBuilder.Options.FindExtension<TOptionsExtension>() ?? new TOptionsExtension();

            ((IDbContextOptionsBuilderInfrastructure)coreOptionsBuilder).AddOrUpdateExtension(extension);

            return optionsBuilder;
        }
    }
}
