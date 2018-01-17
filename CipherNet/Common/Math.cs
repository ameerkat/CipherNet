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

        public static int[][] MatrixMultiply(int[][] a, int[][] b) {
            // Number of rows in A should equal number of columns in B
            if (a.Length != b[0].Length) {
                throw new ArgumentException("a and b are of incompatible dimensions.");
            }

            // Initialize the result
            int[][] result = new int[a.Length][];
            for (int j = 0; j < result.Length; ++j) {
                result[j] = new int[b[0].Length];
            }

            // Calculate
            for (int row = 0; row < a.Length; ++row) {
                for (int col = 0; col < b[row].Length; ++col) {
                    for (int i = 0; i < a[row].Length; ++i) {
                        result[row][col] += a[row][i] * b[i][col];
                    }
                }
            }

            return result;
        }
    }
}
