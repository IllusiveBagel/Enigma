namespace Enigma.Interfaces
{
    public interface IEnigmaService
    {
        string Encrypt(string input);
        char[] RotorOne(char[] input);
    }
}