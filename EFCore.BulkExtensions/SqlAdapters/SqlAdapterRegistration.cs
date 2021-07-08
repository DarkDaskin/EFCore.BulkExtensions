using System;

namespace EFCore.BulkExtensions.SqlAdapters
{
    public class SqlAdapterRegistration
    {
        public string ProviderName { get; }
        public Type SqlOperationsAdapterType { get; }
        public Type QueryBuilderSpecializationType { get; }

        public SqlAdapterRegistration(string providerName, Type sqlOperationsAdapterType, Type queryBuilderSpecializationType)
        {
            if (!typeof(ISqlOperationsAdapter).IsAssignableFrom(sqlOperationsAdapterType))
                throw new ArgumentException("sqlOperationsAdapterType must implement ISqlOperationsAdapter.", 
                    nameof(sqlOperationsAdapterType));
            if (!typeof(IQueryBuilderSpecialization).IsAssignableFrom(queryBuilderSpecializationType))
                throw new ArgumentException("queryBuilderSpecializationType must implement IQueryBuilderSpecialization.", 
                    nameof(queryBuilderSpecializationType));

            ProviderName = providerName;
            SqlOperationsAdapterType = sqlOperationsAdapterType;
            QueryBuilderSpecializationType = queryBuilderSpecializationType;
        }
    }
}
