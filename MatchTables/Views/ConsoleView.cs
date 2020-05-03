using System;
using System.Collections.Generic;
using System.Linq;

namespace MatchTables
{
    public class ConsoleView : IView
    {
        public void ShowAddedItems(IEnumerable<ItemViewData> addedItems)
        {
            PrintListOfItems(addedItems.Select(i => i.PrimaryKeyValue.Trim() + $" ({i.OtherColumnValue.Trim()})"), "Added Items: ");
        }

        public void ShowRemovedItems(IEnumerable<ItemViewData> removesItems)
        {
            PrintListOfItems(removesItems.Select(i => i.PrimaryKeyValue.Trim() + $" ({i.OtherColumnValue.Trim()})"), "Removed Items: ");
        }

        public void ShowChangedItems(Dictionary<string, List<ChangedViewData>> changedItems)
        {
            var items = new List<string>();
            changedItems.Keys.ToList().ForEach(key => 
                changedItems[key].ForEach(v => 
                    items.Add($"{key} {v.ColumnName} has changed from {v.OriginalValue} to {v.ChangedValue}")));

            PrintListOfItems(items, "Changed Items: ");
        }

        public void ShowExceptionMessage(string exMessage)
        {
            Console.WriteLine(exMessage);
        }

        private void PrintListOfItems(IEnumerable<string> items, string title)
        {
            Console.WriteLine(title);
            items.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        }
    }
}
