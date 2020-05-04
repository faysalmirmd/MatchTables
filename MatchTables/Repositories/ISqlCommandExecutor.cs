using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchTables
{
    public interface ISqlCommandExecutor
    {
        Task<List<Dictionary<string, object>>> ExecuteAsync(string sqlQuery);
    }
}
