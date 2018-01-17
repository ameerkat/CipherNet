using CipherNet.Algorithms;
using CipherNet.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class CaesarTests
    {
        private const string TestString = "ATTACKATDAWN";
        private static Alphabet StandardAlphabet = new Alphabet();

        [TestMethod]
        public void EncryptDecryptBasic()
        {
            Caesar cipher = new Caesar(15);
            var intermediaryText = cipher.Encrypt(TestString);
            Assert.AreNotEqual(TestString, intermediaryText);
            var plainText = cipher.Decrypt(intermediaryText);
            Assert.AreEqual(TestString, plainText);
        }
    }
}
