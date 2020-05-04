using System;
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

        public async Task<ValidationResponse> IsValidSchemaAsync(Parameters parameters)
        {
            //Columns type, name matching
            var sqlQueryColumns =
                $"SELECT COLUMN_NAME, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM [INFORMATION_SCHEMA].[COLUMNS] WHERE TABLE_NAME = '{parameters.table1}' " +
                $"EXCEPT SELECT COLUMN_NAME, IS_NULLABLE, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM[INFORMATION_SCHEMA].[COLUMNS] WHERE TABLE_NAME = '{parameters.table2}'";
            var colsResult = await _sqlCommandExecutor.ExecuteAsync(sqlQueryColumns);

            //Primary key matching
            var  sqlQueryPk =
                "SELECT KU.table_name, column_name " +
                "FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS AS TC " +
                "INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE AS KU    " +
                "ON TC.CONSTRAINT_TYPE = 'PRIMARY KEY' AND TC.CONSTRAINT_NAME = KU.CONSTRAINT_NAME " +
                $"AND KU.table_name IN ('{parameters.table1}', '{parameters.table2}') ORDER BY KU.TABLE_NAME, KU.ORDINAL_POSITION;";
             
            var res = await _sqlCommandExecutor.ExecuteAsync(sqlQueryPk);
            var validationResponse = new ValidationResponse(){IsValid = true};
            if (colsResult.Any())
            {
                validationResponse.IsValid = false;
                validationResponse.ReasonPhrase = "Two tables do not share same schema";
                return validationResponse;
            }

            var table1Pks = res.Where(r => ((string)r["table_name"]).Equals(parameters.table1, StringComparison.InvariantCultureIgnoreCase)).Select(i => (string)i["column_name"]);
            var table2Pks = res.Where(r => ((string)r["table_name"]).Equals(parameters.table2, StringComparison.InvariantCultureIgnoreCase)).Select(i => (string)i["column_name"]);

            if (!table1Pks.Contains(parameters.primarykey, StringComparer.CurrentCultureIgnoreCase) || !table2Pks.Contains(parameters.primarykey, StringComparer.CurrentCultureIgnoreCase))
            {
                validationResponse.IsValid = false;
                validationResponse.ReasonPhrase = "Primary Key is invalid";
            }

            return validationResponse;
        }

        public async Task<List<Dictionary<string, object>>> GetAddedItemsAsync(Parameters parameters)
        {
            var sqlQuery = $"Select t2.* from [{parameters.table2}] t2 left join [{parameters.table1}] t1 on t2.[{parameters.primarykey}] = t1.[{parameters.primarykey}] where t1.[{parameters.primarykey}] is null";
            return await _sqlCommandExecutor.ExecuteAsync(sqlQuery);
        }

        public async Task<List<Dictionary<string, object>>> GetRemovedItemsAsync(Parameters parameters)
        {
            var sqlQuery = $"Select t1.* from [{parameters.table1}] t1 left join [{parameters.table2}] t2 on t2.[{parameters.primarykey}] = t1.[{parameters.primarykey}] where t2.[{parameters.primarykey}] is null";
            return await _sqlCommandExecutor.ExecuteAsync(sqlQuery);
        }

        public async Task<Dictionary<string, List<ChangedViewData>>> GetChangedItemsAsync(Parameters parameters)
        {
            var response = new Dictionary<string, List<ChangedViewData>>();

            var sqlQuery = $"select * from [{parameters.table1}] where [{parameters.primarykey}] not in (Select t1.[{parameters.primarykey}] from [{parameters.table1}] t1 left join [{parameters.table2}] t2 on t2.[{parameters.primarykey}] = t1.[{parameters.primarykey}] where t2.[{parameters.primarykey}] is null)"+
            $" except select * from [{parameters.table2}]";

            var originalDataFromTable1 = await _sqlCommandExecutor.ExecuteAsync(sqlQuery);
            if (!originalDataFromTable1.Any()) return response;

            var keys = originalDataFromTable1.Select(r => "'"+r[parameters.primarykey]+ "'").ToArray();
            
            var sqlQuery1 = $"Select * from [{parameters.table2}] where [{parameters.primarykey}] in ({string.Join(", ", keys)})";
            var distortedDataFromTable2 = await _sqlCommandExecutor.ExecuteAsync(sqlQuery1);

            foreach (var row in originalDataFromTable1)
            {
                var changedValues = new List<ChangedViewData>();
                var distortedRow = distortedDataFromTable2.First(d => d[parameters.primarykey].Equals(row[parameters.primarykey]));
                foreach (var key in distortedRow.Keys)
                {
                    if (distortedRow[key].Equals(row[key])) continue;
                    changedValues.Add(new ChangedViewData() { ColumnName = key, OriginalValue = row[key].ToString(), ChangedValue = distortedRow[key].ToString() });
                }

                response.Add(row[parameters.primarykey].ToString(), changedValues);
            }

            return response;
        }

    }
}
