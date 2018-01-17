using System;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class FourSquare : ICipherAlgorithm
    {
        public Alphabet KeySquare1 { get; private set; }
        public Alphabet KeySquare2 { get; private set; }
        public static Alphabet ReferenceAlphabet = new Alphabet("ABCDEFGHIKLMNOPQRSTUVWXYZ", false);
        public FourSquare(Alphabet keySquare1, Alphabet keySquare2)
        {
            KeySquare1 = keySquare1;
            KeySquare2 = keySquare2;
        }

        private const int SQUARE_SIZE = 5;
        public string Encrypt(string plainText)
        {
            // Pad with X
            if (plainText.Length%2 == 1) {
                plainText += "X";
            }

            plainText = plainText.Replace('J', 'I');
            StringBuilder encryptedText = new StringBuilder();
            for (int i = 0; i < plainText.Length; i += 2) {
                var i0 = ReferenceAlphabet.GetIndex(plainText[i]);
                var row0 = i0 / SQUARE_SIZE;
                var col0 = i0 % SQUARE_SIZE;
                var i1 = ReferenceAlphabet.GetIndex(plainText[i + 1]);
                var row1 = i1 / SQUARE_SIZE;
                var col1 = i1 % SQUARE_SIZE;

                // Take row of 0 and col of 1 to get character 1
                // Take col of 0 and row of 1 to get character 2
                encryptedText.Append(KeySquare1[row0 * SQUARE_SIZE + col1]);
                encryptedText.Append(KeySquare2[row1 * SQUARE_SIZE + col0]);
            }

            return encryptedText.ToString();
        }

        public string Decrypt(string encodedText)
        {
            StringBuilder plainText = new StringBuilder();
            for (int i = 0; i < encodedText.Length; i += 2)
            {
                var i0 = KeySquare1.GetIndex(encodedText[i]);
                var row0 = i0 / SQUARE_SIZE;
                var col0 = i0 % SQUARE_SIZE;
                var i1 = KeySquare2.GetIndex(encodedText[i + 1]);
                var row1 = i1 / SQUARE_SIZE;
                var col1 = i1 % SQUARE_SIZE;

                plainText.Append(ReferenceAlphabet[row0 * SQUARE_SIZE + col1]);
                plainText.Append(ReferenceAlphabet[row1 * SQUARE_SIZE + col0]);
            }

            return plainText.ToString();
        }
    }
}
