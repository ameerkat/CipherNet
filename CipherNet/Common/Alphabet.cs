using System;
using System.Collections.Generic;
using System.Text;

namespace CipherNet.Common
{
    /// <summary>
    /// An alphabet defines the relative ordering of characters (in this case
    /// we only support english characters) within the context of an encryption
    /// or decryption algorithm. An algorithm can have any number of alphabets.
    /// An algorithm with 0 alphabets means the the standard ABCDEFG... is
    /// the implicit alphabet.
    /// </summary>
    public class Alphabet
    {
        public const string StandardOrdering = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private string CharacterOrdering { get; set; }
        public int Length { get { return CharacterOrdering.Length;  }}
        public int[] CharacterIndex;

        public static int[] GenerateIndex(string characterOrdering) {
            int[] index = new int[26];
            for (int i = 0; i < 26; ++i) {
                index[i] = -1; // set as not found for incomplete alphabets
            }

            for (int i = 0; i < characterOrdering.Length; ++i)
            {
                index[characterOrdering[i] - 'A'] = i;
            }
            return index;
        }

        private void GenerateIndex() {
            CharacterIndex = Alphabet.GenerateIndex(CharacterOrdering);
        }

        public Alphabet() {
            CharacterOrdering = StandardOrdering;
            GenerateIndex();
        }

        private string RemoveDuplicates(string keyword)
        {
            HashSet<char> seen = new HashSet<char>(keyword.Length);
            StringBuilder deduppedKeyword = new StringBuilder();
            foreach(char ch in keyword) {
                if (!seen.Contains(ch)) {
                    deduppedKeyword.Append(ch);
                    seen.Add(ch);
                }
            }

            return deduppedKeyword.ToString();
        }

        public Alphabet(string keyword, bool autofill = true) {
            HashSet<char> usedCharacters = new HashSet<char>(keyword);
            StringBuilder characterOrdering = new StringBuilder(keyword);

            if (autofill) {
                for (int i = 'A'; i <= 'Z'; ++i)
                {
                    char c = (char)i;
                    if (!usedCharacters.Contains(c)) {
                        characterOrdering.Append(c);
                    }
                }
            }

            CharacterOrdering = characterOrdering.ToString();
            GenerateIndex();
        }

        public char this[int i] {
            get => CharacterOrdering[i];
        }

        public int GetIndex(char ch) {
            if (ch < 'A' && ch > 'Z') {
                return -1;
            } else {
                return CharacterIndex[ch - 'A'];
            }
        }

        public override string ToString()
        {
            return CharacterOrdering;
        }
    }
}
