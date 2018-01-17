using System;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class ADFGX : ICipherAlgorithm
    {
        public Alphabet KeySquare { get; private set; }
        public string Keyword { get; private set; }

        private Polybius polybius;
        private ColumnarTranspostition columnar;
        public ADFGX(Alphabet key, String keyword)
        {
            KeySquare = key;
            Keyword = keyword;

            polybius = new Polybius(KeySquare, "ADFGX", (ch) => {
                if (ch == 'J') {
                    return 'I';
                }
                return ch;
            });
            columnar = new ColumnarTranspostition(keyword);
        }

        public string Encrypt(string plainText) {
            return columnar.Encrypt(polybius.Encrypt(plainText));
        }

        public string Decrypt(string encodedText) {
            return polybius.Decrypt(columnar.Decrypt(encodedText));
        }
    }
}
