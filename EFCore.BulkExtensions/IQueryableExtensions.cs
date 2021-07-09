using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace EFCore.BulkExtensions
{
    public static class IQueryableExtensions
    {
        public static (string, IEnumerable<DbParameter>) ToParametrizedSql(this IQueryable query)
        {
            const string relationalQueryContextText = "_relationalQueryContext";
            const string relationalCommandCacheText = "_relationalCommandCache";

            const string cannotGetText = "Cannot get";

            var enumerator = query.Provider.Execute<IEnumerable>(query.Expression).GetEnumerator();
            var queryContext = enumerator.Private<RelationalQueryContext>(relationalQueryContextText) ?? throw new InvalidOperationException($"{cannotGetText} {relationalQueryContextText}");
            var parameterValues = queryContext.ParameterValues;

#pragma warning disable EF1001 // Internal EF Core API usage.
            var relationalCommandCache = (RelationalCommandCache)enumerator.Private(relationalCommandCacheText);
#pragma warning restore EF1001

            IRelationalCommand command;
            if (relationalCommandCache != null)
            {
#pragma warning disable EF1001 // Internal EF Core API usage.
                command = relationalCommandCache.GetRelationalCommand(parameterValues);
#pragma warning restore EF1001
            }
            else
            {
                const string selectExpressionText = "_selectExpression";
                const string querySqlGeneratorFactoryText = "_querySqlGeneratorFactory";
                SelectExpression selectExpression = enumerator.Private<SelectExpression>(selectExpressionText) ?? throw new InvalidOperationException($"{cannotGetText} {selectExpressionText}");
                IQuerySqlGeneratorFactory factory = enumerator.Private<IQuerySqlGeneratorFactory>(querySqlGeneratorFactoryText) ?? throw new InvalidOperationException($"{cannotGetText} {querySqlGeneratorFactoryText}");
                command = factory.Create().GetCommand(selectExpression);
            }
            string sql = command.CommandText;

            IEnumerable<DbParameter> parameters;
            using (var dbCommand = queryContext.Connection.DbConnection.CreateCommand()) // Use a DbCommand to convert parameter values using ValueConverters to the correct type.
            {
                foreach (var param in command.Parameters)
                {
                    var values = parameterValues[param.InvariantName];
                    param.AddDbParameter(dbCommand, values);
                }
                parameters = dbCommand.Parameters.Cast<DbParameter>().ToList();
                dbCommand.Parameters.Clear();
            }
            return (sql, parameters);
        }

        private static readonly BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.NonPublic;

        private static object Private(this object obj, string privateField) => obj?.GetType().GetField(privateField, bindingFlags)?.GetValue(obj);

        private static T Private<T>(this object obj, string privateField) => (T)obj?.GetType().GetField(privateField, bindingFlags)?.GetValue(obj);
    }
}
