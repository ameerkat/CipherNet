using System;
using System.Collections.Generic;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Rot13 : ICipherAlgorithm
    {
        private Caesar InternalCipher { get; set; }
        private int Shift { get => InternalCipher.Shift; }
        private Alphabet Alphabet { get => InternalCipher.Alphabet; }

        public Rot13(int rotationAmount = 13, Alphabet alphabet = null) {
            alphabet = alphabet == null ? new Alphabet() : alphabet;
            InternalCipher = new Caesar(rotationAmount, alphabet);
        }

        public string Encrypt(string plainText)
        {
            return InternalCipher.Encrypt(plainText);
        }

        public string Decrypt(string encodedText)
        {
            return InternalCipher.Decrypt(encodedText);
        }

    }
}
