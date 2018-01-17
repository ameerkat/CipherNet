using System;
using CipherNet.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CipherNetTests
{
    [TestClass]
    public class ADFGXVTests
    {
        [TestMethod]
        public void EncryptBasicTest()
        {
            ADFGVX adfgvx = new ADFGVX(new CipherNet.Common.Alphabet("PH0QG64MEA1YL2NOFDXKR3CVS5ZW7BJ9UTI8", false), "GERMAN");
            var encryptedText = adfgvx.Encrypt("DEFENDTHEEASTWALLOFTHECASTLE");
            Assert.AreEqual("FFDVDFADFXXFGFGAVFAFFDXDXFFDVDFFDGGAGVGXVXFAGGDGAXDFADVFXGXX", encryptedText);
        }

        [TestMethod]
        public void DecryptBasicTest()
        {
            ADFGVX adfgvx = new ADFGVX(new CipherNet.Common.Alphabet("PH0QG64MEA1YL2NOFDXKR3CVS5ZW7BJ9UTI8", false), "GERMAN");
            var encryptedText = adfgvx.Decrypt("FFDVDFADFXXFGFGAVFAFFDXDXFFDVDFFDGGAGVGXVXFAGGDGAXDFADVFXGXX");
            // Starts with as the result could (and will) be padded
            Assert.IsTrue(encryptedText.StartsWith("DEFENDTHEEASTWALLOFTHECASTLE", StringComparison.Ordinal));
        }
    }
}
