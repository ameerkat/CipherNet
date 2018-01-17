using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class ColumnarTranspostition : ICipherAlgorithm
    {
        public string Keyword { get; private set; }
        public bool Padded { get; private set; }
        public char PaddingChar { get; set; }

        private int[] ModIndex;
        private int[] ReverseModIndex;
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
            // Take each of those and generate a reverse ordering
            ReverseModIndex = new int[keyword.Length];
            for (int i = 0; i < keyword.Length; ++i) {
                ReverseModIndex[ModIndex[i]] = i;
            }

            PaddingChar = 'X';
        }

        private string ColumnarTranspose(string toTranspose, int[] transpositionIndex) {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < transpositionIndex.Length; ++i)
            {
                var thisMod = transpositionIndex[i];
                for (int s = thisMod; s < toTranspose.Length; s += Keyword.Length)
                {
                    output.Append(toTranspose[s]);
                }
            }

            return output.ToString();
        }

        public string Encrypt(string plainText) {
            if (Padded && plainText.Length%Keyword.Length != 0) {
                var amountToPad = Keyword.Length - (plainText.Length % Keyword.Length);
                StringBuilder padder = new StringBuilder();
                padder.Append(PaddingChar, amountToPad);
                plainText = plainText + padder.ToString();
            }

            return ColumnarTranspose(plainText, ModIndex);
        }

        public string Decrypt(string encryptedText) {
            /* Build Columns */
            StringBuilder[] columnBuilder = new StringBuilder[Keyword.Length];
            for (int i = 0; i < encryptedText.Length; ++i)
            {
                var columnIndex = i / (encryptedText.Length/Keyword.Length);
                if (columnBuilder[columnIndex] == null)
                {
                    columnBuilder[columnIndex] = new StringBuilder();
                }

                columnBuilder[columnIndex].Append(encryptedText[i]);
            }

            /* Read off in reverse column order */
            string[] columns = columnBuilder.Select(x => x.ToString()).ToArray();
            StringBuilder output = new StringBuilder();
            for (int row = 0; row < encryptedText.Length / Keyword.Length; ++row) {
                for (int i = 0; i < Keyword.Length; ++i) {
                    output.Append(columns[ReverseModIndex[i]][row]);
                }
            }

            return output.ToString();
        }
    }
}
