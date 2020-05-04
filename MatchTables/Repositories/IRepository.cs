using System.Collections.Generic;
using System.Threading.Tasks;

namespace MatchTables
{
    public interface IRepository
    {
        Task<ValidationResponse> IsValidSchemaAsync(Parameters parameters);
        Task<List<Dictionary<string, object>>> GetAddedItemsAsync(Parameters parameters);
        Task<List<Dictionary<string, object>>> GetRemovedItemsAsync(Parameters parameters);
        Task<Dictionary<string, List<ChangedViewData>>> GetChangedItemsAsync(Parameters parameters);
    }
}
