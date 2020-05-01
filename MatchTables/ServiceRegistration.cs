using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MatchTables
{
    public static class ServiceRegistration
    {
        public static IServiceCollection RegisterServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IView, ConsoleView>();
            serviceCollection.AddSingleton<IRepository, Repository>();
            serviceCollection.AddSingleton<IArgumentParser, ArgumentParser>();
            serviceCollection.AddSingleton<IController, Controller>();
            serviceCollection.AddSingleton<ISqlCommandExecutor, SqlCommandExecutor>();
            return serviceCollection;
        }
    }
}
