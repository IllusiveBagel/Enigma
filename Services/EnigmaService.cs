using System.Text;

using Microsoft.Extensions.Configuration;

using Enigma.Interfaces;

namespace Enigma.Services
{
    public class EnigmaService : IEnigmaService
    {
        private readonly IConfigurationRoot _config;
        private readonly int[] _rotors;
        private readonly string[] _notchPositions;
        private readonly string[] _plugboard;
        private readonly string[] _initialRotorPositions;

        public EnigmaService(IConfigurationRoot config)
        {
            // Get All Config Data From appsettings.json
            var machineSettings = config.GetSection("MachineSettings");
            _rotors = machineSettings.GetSection("Rotors").Get<int[]>();
            _notchPositions = machineSettings.GetSection("NotchPositions").Get<string[]>();
            _plugboard = machineSettings.GetSection("Plugboard").Get<string[]>();
            _initialRotorPositions= machineSettings.GetSection("InitialRotorPositions").Get<string[]>();
        }

        public string Encrypt(string input)
        {
            StringBuilder retData = new StringBuilder();

            retData.AppendLine($"Rotors: {string.Join(", ", _rotors)}");
            retData.AppendLine($"Notch Positions: {string.Join(", ", _notchPositions)}");
            retData.AppendLine($"Plugboard: {string.Join(", ", _plugboard)}");
            retData.AppendLine($"Initial Rotor Settings: {string.Join(", ", _initialRotorPositions)}");

            return retData.ToString();
        }
    }
}