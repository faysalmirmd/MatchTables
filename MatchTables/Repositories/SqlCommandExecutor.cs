using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MatchTables
{
    public class SqlCommandExecutor : ISqlCommandExecutor
    {
        private readonly IConfigurationRoot _configuration;
        private const string ConnectionStringConfigName = "DataConnection";

        public SqlCommandExecutor(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Dictionary<string, string>>> ExecuteAsync(string sqlQuery)
        {
            var data = new List<Dictionary<string, string>>();
            var connectionString = _configuration.GetConnectionString(ConnectionStringConfigName);

            await using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(sqlQuery, connection);
                connection.Open();
                var reader = await command.ExecuteReaderAsync();
                try
                {
                    var columns = GetColumnNamesAsync(reader);

                    while (reader.Read())
                    {
                        var dic = new Dictionary<string, string>();
                        columns.ForEach(c => dic.Add(c, reader[c].ToString()));
                        data.Add(dic);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return data;
        }

        private static List<string> GetColumnNamesAsync(IDataRecord reader)
        {
            var columns = new List<string>();

            for (var i = 0; i < reader.FieldCount; i++)
            {
                columns.Add(reader.GetName(i));
            }

            return columns;
        }
    }
}
