using Microsoft.Data.SqlClient;

namespace EFCore.BulkExtensions.SqlServer
{
    public class BulkConfigSqlServerOptions : IBulkConfigProviderOptions
    {
        /// <summary>
        ///     Enum with [Flags] attribute which enables specifying one or more options.
        /// </summary>
        /// <value>
        ///     <c>Default, KeepIdentity, CheckConstraints, TableLock, KeepNulls, FireTriggers, UseInternalTransaction</c>
        /// </value>
        public SqlBulkCopyOptions SqlBulkCopyOptions { get; set; }
    }
}
