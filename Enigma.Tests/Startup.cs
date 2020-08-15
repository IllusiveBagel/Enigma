using System;
using System.IO;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Enigma.Services;
using Enigma.Interfaces;

namespace Enigma.Tests
{
    public class Startup
    {
        public static IConfigurationRoot configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // Add Configuration File
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add Access to Generic IConfigurationRoot
            services.AddSingleton<IConfigurationRoot>(configuration);

            // Add Enigma Service
            services.AddTransient<IEnigmaService, EnigmaService>();
        }
    }
}