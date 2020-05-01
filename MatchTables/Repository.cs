using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchTables
{
    public class Repository : IRepository
    {
        private readonly ISqlCommandExecutor _sqlCommandExecutor;

        public Repository(ISqlCommandExecutor sqlCommandExecutor)
        {
            _sqlCommandExecutor = sqlCommandExecutor;
        }

        public async Task<bool> IsSchemaSame(Parameters parameters)
        {
            //TODO:will be implemented later
            //var sqlQuery = "SELECT COLUMN_NAME, IS_NULLABLE,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM [INFORMATION_SCHEMA].[COLUMNS] SC1 WHERE SC1.TABLE_NAME = 'NewTable' and TABLE_CATALOG = 'Test2'";
            //var res = await _sqlCommandExecutor.Execute(sqlQuery);
            return true;
        }

        public async Task<List<Dictionary<string, string>>> GetAddedItems(Parameters parameters)
        {
            var sqlQuery = $"Select t2.* from {parameters.table2} t2 left join {parameters.table1} t1 on t2.{parameters.primarykey} = t1.{parameters.primarykey} where t1.{parameters.primarykey} is null";
            return await _sqlCommandExecutor.Execute(sqlQuery);
        }

        public async Task<List<Dictionary<string, string>>> GetRemovedItems(Parameters parameters)
        {
            var sqlQuery = $"Select t1.* from {parameters.table1} t1 left join {parameters.table2} t2 on t2.{parameters.primarykey} = t1.{parameters.primarykey} where t2.{parameters.primarykey} is null";
            return await _sqlCommandExecutor.Execute(sqlQuery);
        }

        public async Task<Dictionary<string, List<Data>>> GetChangedItems(Parameters parameters)
        {
            var sqlQuery = $"select * from {parameters.table1} where {parameters.primarykey} not in (Select t1.{parameters.primarykey} from {parameters.table1} t1 left join {parameters.table2} t2 on t2.{parameters.primarykey} = t1.{parameters.primarykey} where t2.{parameters.primarykey} is null)"+
            $" except select * from {parameters.table2}";

            var originalDataFromTable1 = await _sqlCommandExecutor.Execute(sqlQuery);
            var keys = originalDataFromTable1.Select(r => r[parameters.primarykey]).ToArray();
            
            var sqlQuery1 = $"Select * from {parameters.table2} where {parameters.primarykey} in ({string.Join(", ", keys)})";
            var distortedDataFromTable2 = await _sqlCommandExecutor.Execute(sqlQuery1);

            var response = new Dictionary<string, List<Data>>();
            foreach (var row in originalDataFromTable1)
            {
                var changedValues = new List<Data>();
                var distortedRow = distortedDataFromTable2.First(d => d[parameters.primarykey].Equals(row[parameters.primarykey]));
                foreach (var key in distortedRow.Keys)
                {
                    if (distortedRow[key].Equals(row[key])) continue;
                    changedValues.Add(new Data() { ColumnName = key, OriginalValue = row[key], ChangedValue = distortedRow[key] });
                }

                response.Add(row[parameters.primarykey], changedValues);
            }

            return response;
        }

    }
}
