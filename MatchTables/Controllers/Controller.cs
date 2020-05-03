using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchTables
{
    public class Controller: IController
    {
        private readonly IView _view;
        private readonly IRepository _repository;

        public Controller(IView view, IRepository repository)
        {
            _view = view;
            _repository = repository;
        }

        public async Task RunAsync(Parameters parameters)
        {
            await ExecuteAddedItemsAsync(parameters);
            await ExecuteRemovedItemsAsync(parameters);
            await ExecuteChangedItemsAsync(parameters);
        }

        public async Task<ValidationResponse> IsSchemaValidAsync(Parameters parameters)
        {
            return await _repository.IsValidSchemaAsync(parameters);
        }

        private async Task ExecuteAddedItemsAsync(Parameters parameters)
        {
            var addedItems = await _repository.GetAddedItemsAsync(parameters);
            var otherColName = addedItems.FirstOrDefault()?.Keys?.First(k => !k.Equals(parameters.primarykey));
            _view.ShowAddedItems(addedItems.Select(i =>  new ItemViewData {PrimaryKeyValue = i[parameters.primarykey], OtherColumnValue = otherColName !=  null ? i[otherColName] : null }));
        }

        private async Task ExecuteRemovedItemsAsync(Parameters parameters)
        {
            var removedItems = await _repository.GetRemovedItemsAsync(parameters);
            var otherColName = removedItems.FirstOrDefault()?.Keys?.First(k => !k.Equals(parameters.primarykey));
            _view.ShowRemovedItems(removedItems.Select(i => new ItemViewData { PrimaryKeyValue = i[parameters.primarykey], OtherColumnValue = otherColName != null ? i[otherColName] : null }));
        }

        private async Task ExecuteChangedItemsAsync(Parameters parameters)
        {
            var changedItems = await _repository.GetChangedItemsAsync(parameters);
            _view.ShowChangedItems(changedItems);
        }
    }
}
