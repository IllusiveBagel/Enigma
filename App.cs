using System;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;

using Enigma.Interfaces;

namespace Enigma
{
    public class App
    {
        private readonly IConfigurationRoot _config;
        private readonly IEnigmaService _enigmaService;

        public App(IConfigurationRoot configuration, IEnigmaService enigmaService)
        {
            _config = configuration;
            _enigmaService = enigmaService;
        }

        public async Task Run()
        {
            Console.WriteLine(_enigmaService.Encrypt(""));
        }
    }
}