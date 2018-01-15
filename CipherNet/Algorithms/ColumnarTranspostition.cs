using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CipherNet.Algorithms
{
    public class ColumnarTranspostition
    {
        public string Keyword { get; private set; }
        public bool Padded { get; private set; }
        public char PaddingChar { get; set; }

        private int[] ModIndex;
        private static IList<int> GetIndexOrder(string keyword) {
            int[] items = new int[keyword.Length];
            for (int i = 0; i < items.Length; ++i) {
                items[i] = i;
            }

            Array.Sort(keyword.ToCharArray(), items);
            return items;
        }

        public ColumnarTranspostition(string keyword, bool padded = true)
        {
            Keyword = keyword;
            Padded = padded;
            ModIndex = GetIndexOrder(keyword).ToArray();
            PaddingChar = 'X';
        }

        public string Encrypt(string plainText) {
            if (Padded) {
                var amountToPad = Keyword.Length - (plainText.Length % Keyword.Length);
                StringBuilder padder = new StringBuilder();
                padder.Append(PaddingChar, amountToPad);
                plainText = plainText + padder.ToString();
            }

            StringBuilder output = new StringBuilder();
            for (int i = 0; i < Keyword.Length; ++i) {
                var thisMod = ModIndex[i];
                for (int s = thisMod; s < plainText.Length; s += Keyword.Length) {
                    output.Append(plainText[s]);
                }
            }

            return output.ToString();
        }

        public string Decrypt(string encryptedText) {
            
        }
    }
}
