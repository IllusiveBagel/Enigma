namespace Enigma.Models
{
    public class MachineSettings
    {
        public int[] Rotors { get; set; }
        public string[] NotchPositions { get; set; }
        public string[] Plugboard { get; set; }
        public string[] InitialRotorPositions { get; set; }
    }
}