using CipherNet.Algorithms;
using CipherNet.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class Rot13Tests
    {
        private const string TestString = "ATTACKATDAWN";
        private const string ExpectedString = "NGGNPXNGQNJA";
        private static Alphabet StandardAlphabet = new Alphabet();

        [TestMethod]
        public void EncryptDecryptBasic()
        {
            Rot13 cipher = new Rot13();
            var intermediaryText = cipher.Encrypt(TestString);
            Assert.AreNotEqual(TestString, ExpectedString);
            var plainText = cipher.Decrypt(intermediaryText);
            Assert.AreEqual(TestString, plainText);
        }
    }
}
