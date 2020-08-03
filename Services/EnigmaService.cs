using System.Text;

using Microsoft.Extensions.Configuration;

using Enigma.Interfaces;

namespace Enigma.Services
{
    public class EnigmaService : IEnigmaService
    {
        private readonly IConfigurationRoot _config;
        private readonly int[] _rotors;
        private readonly string[] _ringSettings;
        private readonly string[] _plugboard;
        private readonly string[] _initialRotorSettings;

        public EnigmaService(IConfigurationRoot config)
        {
            // Get All Config Data From appsettings.json
            _rotors = config.GetSection("Rotors").Get<int[]>();
            _ringSettings = config.GetSection("RingSettings").Get<string[]>();
            _plugboard = config.GetSection("Plugboard").Get<string[]>();
            _initialRotorSettings = config.GetSection("InitialRotorSetting").Get<string[]>();
        }

        public string Encrypt(string input)
        {
            StringBuilder retData = new StringBuilder();

            retData.AppendLine($"Rotors: {string.Join(", ", _rotors)}");
            retData.AppendLine($"Ring Settings: {string.Join(", ", _ringSettings)}");
            retData.AppendLine($"Plugboard: {string.Join(", ", _plugboard)}");
            retData.AppendLine($"Initial Rotor Settings: {string.Join(", ", _initialRotorSettings)}");

            return retData.ToString();
        }
    }
}