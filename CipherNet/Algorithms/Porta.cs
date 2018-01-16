using System;
using System.Linq;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class Porta : ICipherAlgorithm
    {
        public static Alphabet[] alphabets = new Alphabet[] {
            new Alphabet("NOPQRSTUVWXYZ"), // A,B
            new Alphabet("OPQRSTUVWXYZNM"), // C,D
            new Alphabet("PQRSTUVWXYZNOLM"), // E,F
            new Alphabet("QRSTUVWXYZNOPKLM"), // G,H
            new Alphabet("RSTUVWXYZNOPQJKLM"), // I,J
            new Alphabet("STUVWXYZNOPQRIJKLM"), // K,L
            new Alphabet("TUVWXYZNOPQRSHIJKLM"), // M,N
            new Alphabet("UVWXYZNOPQRSTGHIJKLM"), // O,P
            new Alphabet("VWXYZNOPQRSTUFGHIJKLM"), // Q,R
            new Alphabet("WXYZNOPQRSTUVEFGHIJKLM"), // S,T
            new Alphabet("XYZNOPQRSTUVWDEFGHIJKLM"), // U,V
            new Alphabet("YZNOPQRSTUVWXCDEFGHIJKLM"), // W,X
            new Alphabet("ZNOPQRSTUVWXYBCDEFGHIJKLM"), // Y,Z
        };

        public string Keyword { get; private set; }
        public int[] KeywordAlphabets { get; private set; }
        private Alphabet Alphabet { get; set; }

        public Porta(string keyword)
        {
            Keyword = keyword;
            Alphabet = new Alphabet();
            KeywordAlphabets = new int[Keyword.Length];
            for (int i = 0; i < Keyword.Length; ++i) {
                KeywordAlphabets[i] = (Keyword[i] - 'A') / 2;
            }
        }

        public string Encrypt(string plainText)
        {
            StringBuilder encryptedOutput = new StringBuilder();
            for (int i = 0; i < plainText.Length; ++i) {
                Alphabet alphabetToUse = alphabets[KeywordAlphabets[i%KeywordAlphabets.Length]];
                encryptedOutput.Append(alphabetToUse[plainText[i] - 'A']);
            }

            return encryptedOutput.ToString();
        }

        public string Decrypt(string encodedText)
        {
            return Encrypt(encodedText);
        }
    }
}
