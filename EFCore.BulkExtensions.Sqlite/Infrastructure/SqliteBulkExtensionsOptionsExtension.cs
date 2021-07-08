using EFCore.BulkExtensions.SqlAdapters;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.BulkExtensions.Sqlite.Infrastructure
{
    public class SqliteBulkExtensionsOptionsExtension : OptionsExtensionBase
    {
        public override void ApplyServices(IServiceCollection services)
        {
            services.AddEntityFrameworkBulkExtensionsSqlite();
        }
    }
}
