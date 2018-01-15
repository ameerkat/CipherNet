using System;
using System.Collections.Generic;
using System.Linq;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Caesar : ICipherAlgorithm
    {
        public int Shift { get; private set; }
        public Alphabet Alphabet { get; private set; }
        public Caesar(int shift, Alphabet alphabet = null) {
            alphabet = alphabet == null ? new Alphabet() : alphabet;
            this.Shift = CipherNet.Common.Math.PositiveMod(shift, alphabet.Length);
            this.Alphabet = alphabet;
        }

        public string Encrypt(string plainText)
        {
            return Common.CharacterManipulation.ShiftCharacters(Alphabet, plainText, Alphabet[Shift].ToString());
        }

        public string Decrypt(string encodedText)
        {
            return Common.CharacterManipulation.ShiftCharacters(Alphabet, encodedText, Alphabet[Shift].ToString(), true);
        }
    }
}
