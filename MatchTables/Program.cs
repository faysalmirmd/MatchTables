using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchTables
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices(new ServiceCollection());
            var argumentParser = serviceProvider.GetService<IArgumentParser>();

            while (!argumentParser.IsValid(args))
            {
                //TODO: fix it
                Console.WriteLine("Please enter arguments in this formats -Table1 SourceTable1 -Table2 SourceTable2 -Primarykey PrimaryKeyName");
                args = Console.ReadLine().Split();
            }

            var parameters = argumentParser.Parse(args);
            serviceProvider.GetService<App>().Run(parameters).Wait();
            Console.Read();
        }

        private static IServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddTransient<App>();
            serviceCollection.RegisterServices();

            return serviceCollection.BuildServiceProvider();
        }
    }
}

