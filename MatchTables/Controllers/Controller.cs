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

        public async Task<bool> IsSchemaValidAsync(Parameters parameters)
        {
            return await _repository.IsValidSchemaAsync(parameters);
        }

        private async Task ExecuteAddedItemsAsync(Parameters parameters)
        {
            var addedItems = await _repository.GetAddedItemsAsync(parameters);
            _view.ShowAddedItems(addedItems.Select(i => i[parameters.primarykey]));
        }

        private async Task ExecuteRemovedItemsAsync(Parameters parameters)
        {
            var removedItems = await _repository.GetRemovedItemsAsync(parameters);
            _view.ShowRemovedItems(removedItems.Select(i => i[parameters.primarykey]));
        }

        private async Task ExecuteChangedItemsAsync(Parameters parameters)
        {
            var changedItems = await _repository.GetChangedItemsAsync(parameters);
            _view.ShowChangedItems(changedItems);
        }
    }
}
