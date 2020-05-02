using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

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
                Console.WriteLine("Please enter arguments in this formats -Table1 SourceTable1 -Table2 SourceTable2 -Primarykey PrimaryKeyName");
                var input = Console.ReadLine();
                args = input.Split();
            }

            var parameters = argumentParser.Parse(args);
            serviceProvider.GetService<App>().RunAsync(parameters).Wait();
            Console.Read();
        }

        private static IServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
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

