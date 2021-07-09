namespace EFCore.BulkExtensions.SqlServer
{
    public static class BulkConfigExtensions
    {
        public static BulkConfigSqlServerOptions GetSqlServerOptions(this BulkConfig bulkConfig) =>
            bulkConfig.GetProviderOptions<BulkConfigSqlServerOptions>();
    }
}
