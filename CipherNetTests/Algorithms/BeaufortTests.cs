using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class BeaufortTests
    {
        [TestMethod]
        public void EncryptBasicTest() {
            Beaufort bf = new Beaufort("FORTIFICATION");
            var encrypted = bf.Encrypt("DEFENDTHEEASTWALLOFTHECASTLE");
            Assert.AreEqual("CKMPVCPVWPIWUJOGIUAPVWRIWUUK", encrypted);
        }

        [TestMethod]
        public void DecryptBasicTest()
        {
            Beaufort bf = new Beaufort("FORTIFICATION");
            var plainText = bf.Decrypt("CKMPVCPVWPIWUJOGIUAPVWRIWUUK");
            Assert.AreEqual("DEFENDTHEEASTWALLOFTHECASTLE", plainText);
        }
    }
}
