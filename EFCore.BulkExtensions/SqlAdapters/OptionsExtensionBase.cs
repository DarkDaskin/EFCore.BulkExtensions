using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.BulkExtensions.SqlAdapters
{
    public abstract class OptionsExtensionBase : IDbContextOptionsExtension
    {
        public abstract void ApplyServices(IServiceCollection services);

        public virtual void Validate(IDbContextOptions options)
        {
        }

        public virtual DbContextOptionsExtensionInfo Info => new ExtensionInfo(this);


        protected class ExtensionInfo : DbContextOptionsExtensionInfo
        {
            public ExtensionInfo(IDbContextOptionsExtension extension) : base(extension)
            {
            }

            public override long GetServiceProviderHashCode() => 0;

            public override void PopulateDebugInfo(IDictionary<string, string> debugInfo)
            {
            }

            public override bool IsDatabaseProvider => false;

            public override string LogFragment => string.Empty;
        }
    }
}
