using EFCore.BulkExtensions.SqlAdapters;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.BulkExtensions.SqlServer.Infrastructure
{
    public class SqlServerBulkExtensionsOptionsExtension : OptionsExtensionBase
    {
        public override void ApplyServices(IServiceCollection services)
        {
            services.AddEntityFrameworkBulkExtensionsSqlServer();
        }
    }
}
