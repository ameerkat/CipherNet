using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CipherNet.Common;

namespace CipherNet.Algorithms
{
    public class RailFence : ICipherAlgorithm
    {
        public int NumberOfRails { get; private set; }
        public RailFence(int n)
        {
            NumberOfRails = n;
        }

        public string Encrypt(string plainText)
        {
            StringBuilder encryptedText = new StringBuilder();
            var mod = (NumberOfRails * 2 - 2);
            for (int m = 0; m <= mod / 2; ++m)
            {
                var  position1 = Common.Math.PositiveMod(m, mod);
                var position2 = Common.Math.PositiveMod(mod - m, mod);
                for (int i = 0; i < plainText.Length; ++i)
                {
                    if (i%mod == position1)
                    {
                        encryptedText.Append(plainText[i]);
                    } 
                    else if (i%mod == position2) // the else will take care of the case when both are active
                    {
                        encryptedText.Append(plainText[i]);
                    }
                }
            }

            return encryptedText.ToString();
        }

        public string Decrypt(string encodedText)
        {
            // We'll use a more simulative approach as the calculations are more involved here
            int[] railLetterCount = new int[NumberOfRails];
            bool down = true;
            int inRailCount = 0;
            for (int i = 0; i < encodedText.Length; ++i) {
                railLetterCount[inRailCount]++;
                if (inRailCount == NumberOfRails - 1) {
                    down = false;
                } else if (inRailCount == 0) {
                    down = true;
                }

                if (down) {
                    inRailCount++;
                } else {
                    inRailCount--;
                }
            }

            Stack<char>[] rails = new Stack<char>[NumberOfRails];
            var lastIndex = 0;
            for (int r = 0; r < rails.Length; ++r) {
                rails[r] = new Stack<char>(encodedText.Substring(lastIndex, railLetterCount[r]).Reverse());
                lastIndex += railLetterCount[r];
            }

            down = true;
            inRailCount = 0;
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < encodedText.Length; ++i)
            {
                var nextLetter = rails[inRailCount].Pop();
                output.Append(nextLetter);
                if (inRailCount == NumberOfRails - 1) {
                    down = false;
                } else if (inRailCount == 0) {
                    down = true;
                }

                if (down) {
                    inRailCount++;
                } else {
                    inRailCount--;
                }
            }

            return output.ToString();
        }
    }
}
