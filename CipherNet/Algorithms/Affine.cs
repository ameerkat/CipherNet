using System;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Affine : ICipherAlgorithm
    {
        public Alphabet Alphabet { get; private set; }
        public Alphabet MappedAlphabet { get; private set; }
        public int A { get; private set; }
        public int B { get; private set; }

        public Affine(int a, int b, Alphabet alphabet = null)
        {
            Alphabet = alphabet == null ? new Alphabet() : alphabet;
            A = a;
            B = b;

            if(Common.Math.GCD(A, Alphabet.Length) != 1) {
                throw new ArgumentException("a must be relatively prime to the length of the alphabet.", nameof(a));
            }

            StringBuilder mappedAlphabet = new StringBuilder();
            for (int i = 0; i < Alphabet.Length; ++i) {
                var mappedCharIndex = Common.Math.PositiveMod((A * i) + B, Alphabet.Length);
                mappedAlphabet.Append(Alphabet[mappedCharIndex]);
            }

            MappedAlphabet = new Alphabet(mappedAlphabet.ToString());
        }

        public string Encrypt(string plainText) {
            StringBuilder encryptedText = new StringBuilder();
            for (int i = 0; i < plainText.Length; ++i) {
                var plainTextCharacter = plainText[i];
                var normalAlphabetPosition = Alphabet.GetIndex(plainTextCharacter);
                encryptedText.Append(MappedAlphabet[normalAlphabetPosition]);
            }

            return encryptedText.ToString();
        }

        public string Decrypt(string encodedText) {
            StringBuilder plainText = new StringBuilder();
            for (int i = 0; i < encodedText.Length; ++i)
            {
                var encodedCharacter = encodedText[i];
                plainText.Append(Alphabet[MappedAlphabet.GetIndex(encodedCharacter)]);
            }

            return plainText.ToString();
        }
    }
}
