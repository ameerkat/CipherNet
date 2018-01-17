using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class ADFGXTests
    {
        [TestMethod]
        public void EncryptBasicTest() {
            ADFGX adfgx = new ADFGX(new CipherNet.Common.Alphabet("PHQGMEAYNOFDXKRCVSZWBUTIL", false), "GERMAN");
            var encryptedText = adfgx.Encrypt("ATTACK");
            Assert.AreEqual("XFDDDDFAFGXG", encryptedText);
        }

        [TestMethod]
        public void DecryptBasicTest() {
            ADFGX adfgx = new ADFGX(new CipherNet.Common.Alphabet("PHQGMEAYNOFDXKRCVSZWBUTIL", false), "GERMAN");
            var encryptedText = adfgx.Decrypt("XFDDDDFAFGXG");
            Assert.AreEqual("ATTACK", encryptedText);
        }
    }
}
