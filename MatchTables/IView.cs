using System.Collections.Generic;

namespace MatchTables
{
    public interface IView
    {
        void ShowAddedItems(IEnumerable<string> addedItems);
        void ShowRemovedItems(IEnumerable<string> addedItems);
        void ShowChangedItems(Dictionary<string, List<Data>> changedItems);
        void ShowExceptionMessage(string exMessage);
    }
}
