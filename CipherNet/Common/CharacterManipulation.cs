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
    }
}
