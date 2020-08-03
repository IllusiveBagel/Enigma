using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

namespace Enigma
{
    public class App
    {
        private readonly IConfigurationRoot _config;

        public App(IConfigurationRoot configuration)
        {
            _config = configuration;
        }

        public async Task Run()
        {
            Console.WriteLine("Hello World!");
        }
    }
}