using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Enigma.Services;
using Enigma.Interfaces;

namespace Enigma
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static int Main(string[] args)
        {
            try
            {
                // Start Code
                MainAsync(args).Wait();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        static async Task MainAsync(string[] args)
        {
            ServiceCollection ServiceCollection = new ServiceCollection();
            ConfigureServices(ServiceCollection);
            ServiceProvider serviceProvider = ServiceCollection.BuildServiceProvider();

            try 
            {
                await serviceProvider.GetService<App>().Run();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            // Add Configuration File
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add Access to Generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            // Add Services
            serviceCollection.AddSingleton<IEnigmaService, EnigmaService>();

            // Add App
            serviceCollection.AddTransient<App>();
        }
    }
}
