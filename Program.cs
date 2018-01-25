using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage;
using Serilog;
using Serilog.Events;

namespace Com.Bekijkhet.SerilogTablestorageExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            ConfigureServices(serviceCollection);

             var serviceProvider = serviceCollection.BuildServiceProvider();
 
            serviceProvider.GetService<App>().Run();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection) {
            serviceCollection.AddSingleton(new LoggerFactory()
                .AddSerilog());
            serviceCollection.AddLogging();

            CloudStorageAccount logStorageAccount = CloudStorageAccount.Parse("UseDevelopmentStorage=true");

            // Initialize serilog logger
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.AzureTableStorage(logStorageAccount, LogEventLevel.Verbose, null, "combekijkhetserilogtablestorageexample", false, null, null, new MyKeyGenerator())
                 .MinimumLevel.Debug()
                 .Enrich.FromLogContext()
                 .CreateLogger();

            serviceCollection.AddTransient<App>();
        }
    }
}
