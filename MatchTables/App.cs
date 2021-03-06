﻿using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MatchTables
{
    public class App
    {
        private readonly IController _controller;
        private readonly IView _view;

        public App(IController controller, IView view)
        {
            _controller = controller;
            _view = view;
        }

        public async Task RunAsync(Parameters parameters)
        {
            try
            {
                var validationResponse = await _controller.IsSchemaValidAsync(parameters);
                if (!validationResponse.IsValid)
                {
                    _view.ShowExceptionMessage(validationResponse.ReasonPhrase);
                    return;
                }

                await _controller.RunAsync(parameters);
            }
            catch (SqlException ex)
            {
                _view.ShowExceptionMessage(ex.Message);
            }
            catch (Exception ex)
            {
                _view.ShowExceptionMessage(ex.Message);
            }
        }
    }
}
