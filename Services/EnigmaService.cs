using System.Text;

using Microsoft.Extensions.Configuration;

using Enigma.Models;
using Enigma.Interfaces;

namespace Enigma.Services
{
    public class EnigmaService : IEnigmaService
    {
        private readonly IConfigurationRoot _config;
        private readonly MachineSettings _machineSettings;

        public EnigmaService(IConfigurationRoot config)
        {
            // Get All Config Data From appsettings.json
            _machineSettings = config.GetSection("MachineSettings").Get<MachineSettings>();
        }

        public string Encrypt(string input)
        {
            StringBuilder retData = new StringBuilder();

            retData.AppendLine($"Rotors: {string.Join(", ", _machineSettings.Rotors)}");
            retData.AppendLine($"Notch Positions: {string.Join(", ", _machineSettings.NotchPositions)}");
            retData.AppendLine($"Plugboard: {string.Join(", ", _machineSettings.Plugboard)}");
            retData.AppendLine($"Initial Rotor Settings: {string.Join(", ", _machineSettings.InitialRotorPositions)}");

            return retData.ToString();
        }
    }
}