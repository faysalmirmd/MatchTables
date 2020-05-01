using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchTables
{
    public interface IRepository
    {
        Task<bool> IsSchemaSame(Parameters parameters);
        Task<List<Dictionary<string, string>>> GetAddedItems(Parameters parameters);
        Task<List<Dictionary<string, string>>> GetRemovedItems(Parameters parameters);
        Task<Dictionary<string, List<Data>>> GetChangedItems(Parameters parameters);
    }
}
