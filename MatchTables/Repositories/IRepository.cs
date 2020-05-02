using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchTables
{
    public interface IRepository
    {
        Task<bool> IsValidSchemaAsync(Parameters parameters);
        Task<List<Dictionary<string, string>>> GetAddedItemsAsync(Parameters parameters);
        Task<List<Dictionary<string, string>>> GetRemovedItemsAsync(Parameters parameters);
        Task<Dictionary<string, List<ChangedViewData>>> GetChangedItemsAsync(Parameters parameters);
    }
}
