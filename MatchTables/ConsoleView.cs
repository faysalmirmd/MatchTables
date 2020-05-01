using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatchTables
{
    public class ConsoleView : IView
    {
        public void ShowAddedItems(IEnumerable<string> addedItems)
        {
            PrintListOfItems(addedItems, "Added Items: ");
        }

        public void ShowRemovedItems(IEnumerable<string> removesItems)
        {
            PrintListOfItems(removesItems, "Removed Items: ");
        }

        public void ShowChangedItems(Dictionary<string, List<Data>> changedItems)
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
