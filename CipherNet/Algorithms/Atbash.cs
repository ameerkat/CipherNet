using System;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Atbash : ICipherAlgorithm
    {
        private Affine InternalCipher { get; set; }
        public Atbash(Alphabet alphabet = null)
        {
            InternalCipher = new Affine(25, 25, alphabet);
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
