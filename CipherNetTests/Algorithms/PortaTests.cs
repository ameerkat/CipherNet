using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class PortaTests
    {
        [TestMethod]
        public void EncryptBasicTest() {
            Porta p = new Porta("FORTIFICATION");
            var encryptedText = p.Encrypt("DEFENDTHEEASTWALLOFTHECASTLE");
            Assert.AreEqual("SYNNJSCVRNRLAHUTUKUCVRYRLANY", encryptedText);
        }

        [TestMethod]
        public void DecryptBasicTest() {
            Porta p = new Porta("FORTIFICATION");
            var plainText = p.Decrypt("SYNNJSCVRNRLAHUTUKUCVRYRLANY");
            Assert.AreEqual("DEFENDTHEEASTWALLOFTHECASTLE", plainText);
        }
    }
}
