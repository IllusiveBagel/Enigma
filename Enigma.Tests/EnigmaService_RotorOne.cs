using Xunit;

using Enigma.Interfaces;

namespace Enigma.Tests
{
    public class EnigmaService_RotorOne
    {
        private readonly IEnigmaService _enigmaService;
        public EnigmaService_RotorOne(IEnigmaService enigmaService)
        {
            _enigmaService = enigmaService;
        }

        [Fact]
        public void ValidSingleWord()
        {
            //Given
            char[] input = "TEST".ToCharArray();
            char[] expected = "PFXX".ToCharArray();

            //When
            char[] output = _enigmaService.RotorOne(input);
            
            //Then
            Assert.Equal(expected, output);
        }

        [Fact]
        public void ValidMultiWord()
        {
            //Given
            char[] input = "TEST ME".ToCharArray();
            char[] expected = "PFXX VJ".ToCharArray();

            //When
            char[] output = _enigmaService.RotorOne(input);
            
            //Then
            Assert.Equal(expected, output);
        }
    }
}