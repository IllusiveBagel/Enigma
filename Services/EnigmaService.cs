using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;

using Enigma.Models;
using Enigma.Interfaces;

namespace Enigma.Services
{
    public class EnigmaService : IEnigmaService
    {
        private readonly IConfigurationRoot _config;
        private readonly MachineSettings _machineSettings;
        private readonly RotorSettigns _rotorSettings;
        private readonly string[] _reflectorSettings;

        public EnigmaService(IConfigurationRoot config)
        {
            // Get All Config Data From appsettings.json
            _machineSettings = config.GetSection("MachineSettings").Get<MachineSettings>();
            _rotorSettings = config.GetSection("RotorSettings").Get<RotorSettigns>();
            _reflectorSettings = config.GetSection("RefelctorSettings").Get<string[]>();
        }

        public string Encrypt(string input)
        {
            char[] ret = new char[input.Length];

            for(int i = 0; i < input.Length; i++)
            {
                foreach(string plug in _machineSettings.Plugboard)
                {
                    char[] plugs = plug.ToCharArray();

                    if(plugs[0] == input[i])
                    {
                        ret[i] = plugs[1];
                    }
                    else
                    {
                        ret[i] = input[i];
                    }
                }
            }

            char[] rotOne = RotorOne(ret);

            return new string(rotOne);
        }

        private char[] RotorOne(char[] input)
        {
            List<char> rotSettings = new List<char>();
            List<char> retLetters = new List<char>();

            // Add Rotor Settings to a List
            foreach(char letter in _rotorSettings.I) 
            {
                rotSettings.Add(letter);
            }

            for(int i = 0; i < input.Length; i++)
            {
                // Replace Letter with Current Rotor Settings
                retLetters.Add(rotSettings[input[i] - 65]);

                // Move the Rotor One Position Forward
                char[] rotSwitch = new char[26];

                for (int j = 0; j < rotSettings.Count; j++)
                {
                    int index = j + 1;

                    if(index == 26)
                    {
                        index = 0;
                    }

                    rotSwitch[index] = rotSettings[j];
                }

                rotSettings = rotSwitch.ToList();
            }

            return retLetters.ToArray();
        }
    }
}