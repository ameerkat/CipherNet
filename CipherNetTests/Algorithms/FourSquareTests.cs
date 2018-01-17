using System;
using CipherNet.Algorithms;
using CipherNet.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class FourSquareTests
    {
        [TestMethod]
        public void EncryptBasicTest() 
        {
            FourSquare fs = new FourSquare(
                new Alphabet("ZGPTFOGHMUWDRCNYKEQAXVSBL"),
                new Alphabet("MFNBDCRHSAXYOGVITUEWLQZKP"));
            var encrypted = fs.Encrypt("ATTACKATDAWN");
            Assert.AreEqual("TIYBFHTIZBSY", encrypted);
        }

        [TestMethod]
        public void DecryptBasicTest()
        {
            FourSquare fs = new FourSquare(
                new Alphabet("ZGPTFOGHMUWDRCNYKEQAXVSBL"),
                new Alphabet("MFNBDCRHSAXYOGVITUEWLQZKP"));
            var encrypted = fs.Decrypt("TIYBFHTIZBSY");
            Assert.AreEqual("ATTACKATDAWN", encrypted);
        }
    }
}
