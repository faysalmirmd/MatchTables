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

        public async Task Run(Parameters parameters)
        {
            await ExecuteAddedItems(parameters);
            await ExecuteRemovedItems(parameters);
            await ExecuteRChangedItems(parameters);
        }

        public async Task<bool> IsSchemaSame(Parameters parameters)
        {
            return await _repository.IsSchemaSame(parameters);
        }

        private async Task ExecuteAddedItems(Parameters parameters)
        {
            var addedItems = await _repository.GetAddedItems(parameters);
            _view.ShowAddedItems(addedItems.Select(i => i[parameters.primarykey]));
        }

        private async Task ExecuteRemovedItems(Parameters parameters)
        {
            var removedItems = await _repository.GetRemovedItems(parameters);
            _view.ShowRemovedItems(removedItems.Select(i => i[parameters.primarykey]));
        }

        private async Task ExecuteRChangedItems(Parameters parameters)
        {
            var changedItems = await _repository.GetChangedItems(parameters);
            _view.ShowChangedItems(changedItems);
        }
    }
}
