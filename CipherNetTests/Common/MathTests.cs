using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CipherNet.Common;

namespace CipherNetTests
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void MatrixMultiplyTest() {
            int[][] expectedResult = new int[][] { new int[] { 5, -4 }, new int[] { 4, 5 } };
            int[][] a = new int[][] { new int[] { 1, 2, -1 }, new int[] { 2, 0, 1 } };
            int[][] b = new int[][] { new int[] { 3, 1 }, new int[] { 0, -1 }, new int[] { -2, 3 } };
            var result = CipherNet.Common.Math.MatrixMultiply(a, b);
            for (int i = 0; i < expectedResult.Length; ++i) {
                for (int j = 0; j < expectedResult[i].Length; ++j) {
                    Assert.AreEqual(expectedResult[i][j], result[i][j]);
                }
            } 
        }
    }
}
