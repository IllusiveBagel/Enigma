using System;
using System.IO;

using Microsoft.Extensions.Configuration;

namespace Enigma
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static void Main(string[] args)
        {
            // Add Configuration File
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            Console.WriteLine(configuration.GetSection("test").Value);
        }
    }
}
