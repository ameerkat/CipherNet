using System;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Beaufort : ICipherAlgorithm
    {
        public string Keyword { get; private set; }
        public Alphabet Alphabet { get; private set; }
        public Beaufort(string keyword, Alphabet alphabet = null)
        {
            Keyword = keyword;
            Alphabet = alphabet == null ? new Alphabet() : alphabet;
        }

        public string Encrypt(string plainText)
        {
            var keyText = CharacterManipulation.RepeatToFill(Keyword, plainText.Length);
            return CharacterManipulation.ShiftCharacters(Alphabet, keyText, plainText, true);
        }

        public string Decrypt(string encodedText)
        {
            var keyText = CharacterManipulation.RepeatToFill(Keyword, encodedText.Length);
            return CharacterManipulation.ShiftCharacters(Alphabet, keyText, encodedText, true);
        }
    }
}
