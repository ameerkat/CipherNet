using System;
using System.Collections.Generic;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Autokey
    {
        public Alphabet Alphabet { get; private set; }
        public string Keyword { get; private set; }
        public Autokey(string keyword, Alphabet alphabet = null)
        {
            Keyword = keyword;
            Alphabet = alphabet == null ? new Alphabet() : alphabet;
        }

        public string Encrypt(string plainText) {
            string keyText = Keyword + plainText.Substring(0, plainText.Length - Keyword.Length);
            return CharacterManipulation.ShiftCharacters(Alphabet, plainText, keyText);
        }

        public string Decrypt(string encodedText) {
            /* In this case we must take a streaming approach */
            Queue<char> keyQueue = new Queue<char>(Keyword);
            StringBuilder plainText = new StringBuilder();
            foreach(char ch in encodedText) {
                var keyShift = keyQueue.Dequeue();
                var decodedChar = Alphabet[Common.Math.PositiveMod(
                    Alphabet.GetIndex(ch) - Alphabet.GetIndex(keyShift), 
                    Alphabet.Length)];
                plainText.Append(decodedChar);
                keyQueue.Enqueue(decodedChar);
            }

            return plainText.ToString();
        }
    }
}
