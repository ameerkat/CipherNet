using System;
using System.Linq;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Hill : ICipherAlgorithm
    {
        public int[][] Key { get; private set; }
        public int[][] InverseKey { get; private set; }
        public int KeySize { get { return Key.Length; } }
        public Alphabet Alphabet { get; private set; }
        public Hill(int[][] key, Alphabet alphabet = null)
        {
            Key = key;
            Alphabet = alphabet == null ? new Alphabet() : alphabet;

            // Calculate the Inverse Key
        }

        public static int[] KeyMultiply(int[][] key, int[] chunk) {
            int[] result = new int[chunk.Length];
            for (int row = 0; row < key.Length; ++row) {
                for (int col = 0; col < key[row].Length; ++col) {
                    result[row] += key[row][col] * chunk[col];
                }
            }

            return result;
        }

        private static string EncryptByChunks(int[][] key, string text, Alphabet alpha) {
            StringBuilder encryptedText = new StringBuilder();
            int[] plainTextNumbers = text.Select(c => alpha.GetIndex(c)).ToArray();
            for (int i = 0; i < plainTextNumbers.Length; i += key.Length)
            {
                int[] chunk = new int[key.Length];
                for (int j = 0; j < chunk.Length; ++j)
                {
                    chunk[j] = plainTextNumbers[i + j];
                }

                var result = KeyMultiply(key, chunk);
                encryptedText.Append(result.Select(e => alpha[e % alpha.Length]).ToArray());
            }

            return encryptedText.ToString();
        }

        public string Encrypt(string plainText)
        {
            if (plainText.Length%KeySize != 0) {
                StringBuilder padder = new StringBuilder();
                padder.Append('X', KeySize - (plainText.Length % KeySize));
                plainText = plainText + padder.ToString();
            }

            return EncryptByChunks(Key, plainText, Alphabet);
        }

        public string Decrypt(string encodedText)
        {
            return EncryptByChunks(InverseKey, encodedText, Alphabet);
        }
    }
}
