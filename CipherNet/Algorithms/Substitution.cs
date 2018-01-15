using System;
using System.Linq;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Substitution : ICipherAlgorithm
    {
        public Alphabet SubstitutionAlphabet { get; private set; }
        public Substitution(Alphabet substitution)
        {
            SubstitutionAlphabet = substitution;
        }

        public string Encrypt(string plainText)
        {
            return String.Concat(plainText.Select(ch =>
            {
                return SubstitutionAlphabet[ch - 'A'];
            }));
        }

        public string Decrypt(string encodedText)
        {
            return String.Concat(encodedText.Select(ch =>
            {
                return (char)(SubstitutionAlphabet.GetIndex(ch) + 'A');
            }));
        }
    }
}
