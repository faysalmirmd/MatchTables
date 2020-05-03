using System.Collections.Generic;

namespace MatchTables
{
    public interface IView
    {
        void ShowAddedItems(IEnumerable<ItemViewData> addedItems);
        void ShowRemovedItems(IEnumerable<ItemViewData> addedItems);
        void ShowChangedItems(Dictionary<string, List<ChangedViewData>> changedItems);
        void ShowExceptionMessage(string exMessage);
    }
}
