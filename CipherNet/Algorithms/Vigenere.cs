using System;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Vigenere : ICipherAlgorithm
    {
        public string Keyword { get; private set; }
        public Alphabet Alphabet { get; private set; }
        public Vigenere(string keyword, Alphabet alphabet = null)
        {
            Keyword = keyword;
            Alphabet = alphabet == null ? new Alphabet() : alphabet;
        }

        public string Encrypt(string plainText) 
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < plainText.Length; ++i)
            {
                var keywordBaseline = Alphabet.GetIndex(Keyword[i % Keyword.Length]);
                var thisChar = Alphabet.GetIndex(plainText[i]);
                sb.Append(Alphabet[Common.Math.PositiveMod(thisChar + keywordBaseline, Alphabet.Length)]);
            }

            return sb.ToString();
        }

        public string Decrypt(string cipherText)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < cipherText.Length; ++i)
            {
                var keywordBaseline = Alphabet.GetIndex(Keyword[i % Keyword.Length]);
                var thisChar = Alphabet.GetIndex(cipherText[i]);
                sb.Append(Alphabet[Common.Math.PositiveMod(thisChar - keywordBaseline, Alphabet.Length)]);
            }

            return sb.ToString();
        }
    }
}
