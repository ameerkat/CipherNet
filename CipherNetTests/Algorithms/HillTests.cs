using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class HillTests
    {
        [TestMethod]
        public void BasicEncryptTest() {
            var key = new int[][] { new int[]{ 2, 4, 5 }, new int[]{ 9, 2, 1 }, new int[]{ 3, 17, 7 } };
            Hill h = new Hill(key);
            var encrypted = h.Encrypt("ATT");
            Assert.AreEqual("PFO", encrypted);
        }
    }
}
