using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MatchTables
{
    public class App
    {
        private readonly IController _controller;
        private readonly IView _view;
        //private readonly ILogger<App> _logger;

        public App(IController controller, IView view)
        {
            //_logger = loggerFactory.CreateLogger<App>();
            _controller = controller;
            _view = view;
        }

        public async Task Run(Parameters parameters)
        {
            try
            {
                await _controller.Run(parameters);
            }
            catch (SqlException ex)
            {
                _view.ShowExceptionMessage("SQL Exception occurred. Make sure proper connection string provided in app settings.");
                _view.ShowExceptionMessage(ex.Message);
            }
            catch (Exception ex)
            {
                _view.ShowExceptionMessage(ex.Message);
            }
        }
    }
}
