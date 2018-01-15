using System;
namespace CipherNet.Common
{
    public static class Math
    {
        /// <summary>
        /// Returns a positive integer representig n mod m.
        /// </summary>
        /// <returns>n%m, such that n%m > 0</returns>
        /// <param name="n">n</param>
        /// <param name="m">m</param>
        public static int PositiveMod(int n, int m)
        {
            var r = n % m;
            if (r < 0)
            {
                return r + m;
            }
            else
            {
                return r;
            }
        }

        public static int GCD(int a, int b) {
            if (b == 0) {
                return a;
            } else {
                return GCD(b, a % b);
            }
        }
    }
}
