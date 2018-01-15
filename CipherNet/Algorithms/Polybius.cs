using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Polybius : ICipherAlgorithm
    {
        public Dictionary<char, String> ForwardLookupTable { get; private set; }
        public Dictionary<String, char> BackwardLookupTable { get; private set; }
        public Func<char, char> SubstitutionFunction { get; private set; }

        public Polybius(Alphabet key, String index = "ABCDE", Func<char, char> subsititute = null)
        {
            SubstitutionFunction = subsititute;
            if(key.Length != (index.Length * index.Length)) {
                throw new ArgumentException("Alphabet key must be a square.");
            }

            ForwardLookupTable = new Dictionary<char, string>(key.Length);
            BackwardLookupTable = new Dictionary<string, char>(key.Length);
            int keyIndex = 0;
            for (int row = 0; row < index.Length; ++row) {
                for (int col = 0; col < index.Length; ++col) {
                    var replacement = String.Format("{0}{1}", index[row], index[col]);
                    ForwardLookupTable[key[keyIndex]] = replacement;
                    BackwardLookupTable[replacement] = key[keyIndex];
                    keyIndex++;
                }
            }
        }

        public string Encrypt(string plainText)
        {
            if (SubstitutionFunction != null) {
                plainText = String.Concat(plainText.Select(ch => SubstitutionFunction(ch)));
            }

            StringBuilder encryptedText = new StringBuilder();
            for (int i = 0; i < plainText.Length; ++i) {
                encryptedText.Append(ForwardLookupTable[plainText[i]]);
            }
            return encryptedText.ToString();
        }

        public string Decrypt(string encodedText)
        {
            StringBuilder plainText = new StringBuilder();
            for (int i = 0; i < encodedText.Length; i += 2)
            {
                string key = encodedText[i].ToString() + encodedText[i + 1].ToString();
                plainText.Append(BackwardLookupTable[key]);
            }
            return plainText.ToString();
        }
    }
}
