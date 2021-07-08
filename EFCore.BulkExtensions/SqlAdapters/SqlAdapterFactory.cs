using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore.BulkExtensions.SqlAdapters
{
    public class SqlAdapterFactory
    {
        private readonly Dictionary<string, SqlAdapterRegistration> _registrations;

        public SqlAdapterFactory(IEnumerable<SqlAdapterRegistration> registrations)
        {
            _registrations = registrations.ToDictionary(r => r.ProviderName);
        }

        public ISqlOperationsAdapter GetSqlOperationsAdapter(DbContext context) =>
            (ISqlOperationsAdapter)context.GetInfrastructure().GetRequiredService(
                _registrations[context.Database.ProviderName].SqlOperationsAdapterType);

        public IQueryBuilderSpecialization GetQueryBuilderSpecialization(DbContext context) =>
            (IQueryBuilderSpecialization)context.GetInfrastructure().GetRequiredService(
                _registrations[context.Database.ProviderName].QueryBuilderSpecializationType);
    }
}
