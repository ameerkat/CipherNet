using System;
using System.Text;

namespace CipherNet.Common
{
    public static class CharacterManipulation
    {
        public static string ShiftCharacters(Alphabet alphabet, string toShift, string shiftFilter, bool subtractive = false)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < toShift.Length; ++i)
            {
                var shiftAmountIndex = shiftFilter[i % shiftFilter.Length];
                var shiftAmount = alphabet.GetIndex(shiftAmountIndex);
                var currentCharacter = toShift[i];
                var currentIndex = alphabet.GetIndex(currentCharacter);
                var resultIndex = Math.PositiveMod(currentIndex + ((subtractive ? -1 : 1) * shiftAmount), alphabet.Length);
                sb.Append(alphabet[resultIndex]);
            }

            return sb.ToString();
        }

        public static char ShiftCharacter(Alphabet alphabet, char toShift, char shift, bool subtractive = false) {
            var shiftAmount = alphabet.GetIndex(shift);
            var toShiftCharacter = alphabet.GetIndex(toShift);
            return alphabet[Math.PositiveMod(toShiftCharacter + ((subtractive ? -1 : 1) * shiftAmount), alphabet.Length)];
        }

        public static string RepeatToFill(string keyword, int length) {
            StringBuilder keyText = new StringBuilder();
            for (int i = 0; i < length / keyword.Length; ++i) {
                keyText.Append(keyword);
            }

            keyText.Append(keyword.Substring(0,length%keyword.Length));
            return keyText.ToString();
        }

        public static string RotateRight(string toRotate, int n)
        {
            var rotationAmount = Math.PositiveMod(n, toRotate.Length);
            return toRotate.Substring(toRotate.Length - rotationAmount, rotationAmount) + toRotate.Substring(0, rotationAmount + 1);
        }

        public static string RotateLeft(string toRotate, int n)
        {
            var rotationAmount = Math.PositiveMod(n, toRotate.Length);
            return toRotate.Substring(rotationAmount) + toRotate.Substring(0, rotationAmount);
        }
    }
}
